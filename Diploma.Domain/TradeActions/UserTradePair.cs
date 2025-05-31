using Diploma.Domain.Users;

namespace Diploma.Domain.TradeActions
{
    public class UserTradePair
    {
        public virtual User User { get; set; }
        public virtual TradePair TradePair { get; init; }
        public double ActualBuyPrice { get; set; }
        public double ActualSellPrice { get; set; }

        public UserTradePair(User user, TradePair tradePair)
        {
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(tradePair);

            User = user;
            TradePair = tradePair;
        }
    }
}
