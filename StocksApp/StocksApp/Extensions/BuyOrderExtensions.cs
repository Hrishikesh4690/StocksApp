using StocksApp.DTO;
using StocksApp.Models;

namespace StocksApp.Extensions
{
    public static class BuyOrderExtensions
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse
            {
                BuyOrderId = buyOrder.BuyOrderId,
                StockSymbol = buyOrder.StockSymbol,
                StockName = buyOrder.StockName,
                DateTimeOfOrder = buyOrder.DateAndTimeOfOrder,
                Quantity = buyOrder.Quantity,
                Price = buyOrder.Price,
                TradeAmount = buyOrder.Quantity * buyOrder.Price
            };
        }
    }
}
