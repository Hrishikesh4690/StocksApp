using StocksApp.DTO;
using StocksApp.Extensions;
using StocksApp.Helper;
using StocksApp.Models;
using StocksApp.ServiceContracts;

namespace StocksApp.Services
{
    public class StocksServices : IStocksService
    {
        private readonly List<BuyOrder> _buyOrders;

        public StocksServices()
        {
            _buyOrders = new List<BuyOrder>();
        }

        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            if (buyOrderRequest == null)
            {
                throw new ArgumentNullException(nameof(buyOrderRequest));
            }

            ValidationHelper.ModelValidation(buyOrderRequest);

            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();

            buyOrder.BuyOrderId = Guid.NewGuid();

            _buyOrders.Add(buyOrder);

            return buyOrder.ToBuyOrderResponse();
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
