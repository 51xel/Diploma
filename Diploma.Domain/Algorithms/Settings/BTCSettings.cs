namespace Diploma.Domain.Algorithms.Settings
{
    public static class BTCSettings
    {
        public static DateTime DaysPredictionFrom => DateTime.UtcNow.AddDays(1);
        public static DateTime DaysPredictionTo => DateTime.UtcNow.AddDays(DaysToPredict);
        public static int DaysToPredict => 3;
    }
}
