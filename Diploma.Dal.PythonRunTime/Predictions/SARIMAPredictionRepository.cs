using Diploma.Application.Predictions.Interfaces;
using Diploma.Dal.PythonRunTime.Common;
using Diploma.Domain.Common.Helpers;
using Diploma.Domain.Models;
using Diploma.Domain.Predictions;
using Diploma.Domain.Predictions.Settings;
using Python.Runtime;

namespace Diploma.Dal.PythonRunTime.Predictions
{
    internal class SARIMAPredictionRepository : IPredictionRepository
    {
        public ModelType ForModelType => ModelType.SARIMA;

        public List<Prediction> GetPredictions(IPredictionSettings settings, MemoryStream modelStream)
        {
            if (modelStream is null || !modelStream.CanRead)
            {
                throw new ArgumentException("Model stream cannot be null or empty.");
            }

            var sarimaSettings = settings as SARIMAPredictionSettings;

            if (sarimaSettings is null || sarimaSettings.InputData.Count == 0)
            {
                throw new ArgumentException("Input data cannot be null or empty.");
            }

            var predictions = new List<Prediction>();

            PythonEngineControl.Execute(() => 
            {
                byte[] modelBytes = modelStream.ToArray();

                dynamic json = Py.Import("json");
                dynamic joblib = Py.Import("joblib");
                dynamic pandas = Py.Import("pandas");
                dynamic sarimax = Py.Import("statsmodels.tsa.statespace.sarimax");
                dynamic io = Py.Import("io");

                using (PyObject pyStream = io.BytesIO(modelBytes.ToPython()))
                {
                    dynamic model = joblib.load(pyStream);

                    dynamic inputSeries = pandas.Series(sarimaSettings.InputData.ToPython());

                    var predictedPrices = model.predict(start: sarimaSettings.InputData.First(), end: sarimaSettings.InputData[^1]);

                    var totalPredictions = sarimaSettings.InputData.Count;
                    var interval = CalculateInterval(sarimaSettings);

                    for (int i = 0; i < totalPredictions; i++)
                    {
                        var predictionDate = sarimaSettings.From.AddDays(interval * i);

                        var prediction = new Prediction(predictionDate, (double)predictedPrices[i]);

                        predictions.Add(prediction);
                    }
                }
            });

            return predictions;
        }

        private double CalculateInterval(SARIMAPredictionSettings sarimaSettings)
        {
            var totalPredictions = sarimaSettings.InputData.Count;
            var predictionDifference = sarimaSettings.To - sarimaSettings.From;
            var predictionDuration = DateTimeHelper.CalculateDuration(sarimaSettings.TimeRangeType, predictionDifference);

            return predictionDuration / (totalPredictions - 1);
        }
    }
}
