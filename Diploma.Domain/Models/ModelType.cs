namespace Diploma.Domain.Models
{
    /// <summary>
    /// Represents different types of models used in predictions or analysis.
    /// </summary>
    public enum ModelType
    {
        /// <summary>
        /// No specific model type assigned.
        /// </summary>
        None = 0,

        /// <summary>
        /// Seasonal Autoregressive Integrated Moving Average (SARIMA) model.
        /// Used for time series forecasting with seasonality considerations.
        /// </summary>
        SARIMA = 1
    }
}
