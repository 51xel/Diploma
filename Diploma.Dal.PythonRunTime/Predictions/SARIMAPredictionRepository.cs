using Diploma.Application.Predictions.Interfaces;
using Diploma.Dal.PythonRunTime.Common;
using Diploma.Domain.Common.Helpers;
using Diploma.Domain.Models;
using Diploma.Domain.Predictions;
using Diploma.Domain.Predictions.Settings;
using Python.Runtime;

namespace Diploma.Dal.PythonRunTime.Predictions
{
    internal class SarimaPredictionRepository : IPredictionRepository
    {
        public ModelType ForModelType => ModelType.SARIMA;

        // Python libs
        private static dynamic? _joblib;
        private static dynamic? _io;

        static SarimaPredictionRepository()
        {
            PythonEngineControl.Execute(() =>
            {
                _joblib = Py.Import("joblib");
                _io = Py.Import("io");
            });

            if (_joblib is null || _io is null)
            {
                throw new InvalidOperationException("Can`t load python libs");
            }
        }

        public List<Prediction> GetPredictions(IPredictionSettings predictionSettings, MemoryStream modelFile)
        {
            if (modelFile is null || !modelFile.CanRead)
            {
                throw new ArgumentException("Model stream cannot be null or empty.");
            }

            if (predictionSettings is not SarimaPredictionSettings sarimaSettings || sarimaSettings.InputData.Count == 0)
            {
                throw new ArgumentException("Input data cannot be null or empty.");
            }

            var predictions = new List<Prediction>();

            PythonEngineControl.Execute(() => 
            {
                byte[] modelBytes = modelFile.ToArray();
                using PyObject pyStream = _io!.BytesIO(modelBytes.ToPython());
                //TODO save this in memory, speed up?
                var model = _joblib!.load(pyStream);

                var predictedPrices = model.predict(
                    start: sarimaSettings.InputData.First(),
                    end: sarimaSettings.InputData[^1]);

                var totalPredictions = sarimaSettings.InputData.Count;
                var interval = DateTimeHelper.CalculateInterval(sarimaSettings);

                for (int i = 0; i < totalPredictions; i++)
                {
                    var predictionDate = sarimaSettings.From.AddTime(sarimaSettings.TimeRangeType, interval * i);

                    var prediction = new Prediction(predictionDate, (double)predictedPrices[i]);

                    predictions.Add(prediction);
                }
            });

            return predictions;
        }
    }
}
