using Diploma.Domain.Actions;

namespace Diploma.Domain.TradeActions
{
    public class TradePair
    {
        public Guid Id { get; init; }

        public virtual TradeAction BuyAction { get; init; }
        public virtual TradeAction SellAction { get; set; }

        public TradePair() {}

        public TradePair(
            TradeAction buyAction,
            TradeAction sellAction,
            Guid? id = null)
        {
            ArgumentNullException.ThrowIfNull(buyAction, nameof(buyAction));
            ArgumentNullException.ThrowIfNull(sellAction, nameof(sellAction));

            if (buyAction.Type != TradeActionType.Buy)
            {
                throw new InvalidOperationException("Buy action must with with BUY type");
            }

            if (sellAction.Type != TradeActionType.Sell)
            {
                throw new InvalidOperationException("Sell action must with with SELL type");
            }

            Id = id ?? Guid.NewGuid();
            BuyAction = buyAction;
            SellAction = sellAction;
        }
    }
}
