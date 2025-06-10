using StocksApp.DTO;
using StocksApp.ServiceContracts;

namespace StocksApp.Services
{
    public class StocksServices : IStocksService
    {
        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            throw new NotImplementedException();
        }

        public SellOrderResponse CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            throw new NotImplementedException();
        }

        public List<BuyOrderResponse> GetBuyOrders()
        {
            throw new NotImplementedException();
        }

        public List<SellOrderResponse> GetSellOrders()
        {
            throw new NotImplementedException();
        }
    }
}
