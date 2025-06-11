using StocksApp.DTO;
using StocksApp.ServiceContracts;
using StocksApp.Services;

namespace StocksApp.UnitTests
{
    public class StocksServicesTest
    {
        private readonly IStocksService _stocksService;

        public StocksServicesTest()
        {
            _stocksService = new StocksServices();
        }
        #region CreateBuyOrder Tests
        [Fact]
        public void CreateBuyOrder_Null_BuyOrderRequest_ToBeArgumentNullException()
        {
            BuyOrderRequest? buyOrderRequest = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }

        [Theory]
        [InlineData(0)]
        public void CreateBuyOrder_Null_BuyOrderQuantity_LessThanMininmum_ToBeArgumentNullException(uint buyOrderQuantity)
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest { StockName = "Microsoft", StockSymbol = "ABC", DateAndTimeOfOrder = DateTime.Now, Price = 1, Quantity = buyOrderQuantity };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }

        [Theory]
        [InlineData(100001)]
        public void CreateBuyOrder_Null_BuyOrderQuantity_GreaterThanMaximum_ToBeArgumentNullException(uint buyOrderQuantity)
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest { StockName = "Microsoft", StockSymbol = "ABC", DateAndTimeOfOrder = DateTime.Now, Price = 1, Quantity = buyOrderQuantity };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }

        [Theory]
        [InlineData(0)]
        public void CreateBuyOrder_Null_BuyOrderPrice_LessThanMininmum_ToBeArgumentNullException(uint buyOrderPrice)
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest { StockName = "Microsoft", StockSymbol = "ABC", DateAndTimeOfOrder = DateTime.Now, Price = buyOrderPrice, Quantity = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }

        [Theory]
        [InlineData(10001)]
        public void CreateBuyOrder_Null_BuyOrderPrice_GreaterThanMaximum_ToBeArgumentNullException(uint buyOrderPrice)
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest { StockName = "Microsoft", StockSymbol = "ABC", DateAndTimeOfOrder = DateTime.Now, Price = buyOrderPrice, Quantity = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }

        [Fact]
        public void CreateBuyOrder_Null_StockSymbol_ToBeArgumentNullException()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest { StockName = "Microsoft", StockSymbol = null, DateAndTimeOfOrder = DateTime.Now, Price = 1, Quantity = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }

        [Fact]
        public void CreateBuyOrder_DateOfOrderIsLessThanYear2000_ToBeArgumentNullException()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest { StockName = "Microsoft", StockSymbol = "MSFT", DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"), Price = 1, Quantity = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }

        [Fact]
        public void CreateBuyOrder_ValidRequest_ToBeSuccessful()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest { StockName = "Microsoft", StockSymbol = "MSFT", DateAndTimeOfOrder = Convert.ToDateTime("2000-12-31"), Price = 1, Quantity = 1 };

            // Act & Assert
            var buyOrderResponse = _stocksService.CreateBuyOrder(buyOrderRequest);

            Assert.NotEqual(Guid.Empty, buyOrderResponse.BuyOrderId);
        }
        #endregion

        #region CreateSellOrder Tests

        [Fact]
        public void CreateSellOrder_Null_BuyOrderRequest_ToBeArgumentNullException()
        {
            SellOrderRequest? sellOrderRequest = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Theory]
        [InlineData(0)]
        public void CreateSellOrder_Null_SellOrderQuantity_LessThanMininmum_ToBeArgumentNullException(uint sellOrderQuantity)
        {
            SellOrderRequest? sellOrderRequest = new SellOrderRequest { StockName = "Microsoft", StockSymbol = "ABC", DateAndTimeOfOrder = DateTime.Now, Price = 1, Quantity = sellOrderQuantity };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Theory]
        [InlineData(100001)]
        public void CreateSellOrder_Null_SellOrderQuantity_GreaterThanMaximum_ToBeArgumentNullException(uint sellOrderQuantity)
        {
            SellOrderRequest? sellOrderRequest = new SellOrderRequest { StockName = "Microsoft", StockSymbol = "ABC", DateAndTimeOfOrder = DateTime.Now, Price = 1, Quantity = sellOrderQuantity };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Theory]
        [InlineData(0)]
        public void CreateSellOrder_Null_SellOrderPrice_LessThanMininmum_ToBeArgumentNullException(uint sellOrderPrice)
        {
            SellOrderRequest? sellOrderRequest = new SellOrderRequest { StockName = "Microsoft", StockSymbol = "ABC", DateAndTimeOfOrder = DateTime.Now, Price = sellOrderPrice, Quantity = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Theory]
        [InlineData(10001)]
        public void CreateSellOrder_Null_SellOrderPrice_GreaterThanMaximum_ToBeArgumentNullException(uint sellOrderPrice)
        {
            SellOrderRequest? sellOrderRequest = new SellOrderRequest { StockName = "Microsoft", StockSymbol = "ABC", DateAndTimeOfOrder = DateTime.Now, Price = sellOrderPrice, Quantity = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_Null_StockSymbol_ToBeArgumentNullException()
        {
            SellOrderRequest? sellOrderRequest = new SellOrderRequest { StockName = "Microsoft", StockSymbol = null, DateAndTimeOfOrder = DateTime.Now, Price = 1, Quantity = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_DateOfOrderIsLessThanYear2000_ToBeArgumentNullException()
        {
            SellOrderRequest? sellOrderRequest = new SellOrderRequest { StockName = "Microsoft", StockSymbol = "MSFT", DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"), Price = 1, Quantity = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public void CreateSellOrder_ValidRequest_ToBeSuccessful()
        {
            SellOrderRequest? sellOrderRequest = new SellOrderRequest { StockName = "Microsoft", StockSymbol = "MSFT", DateAndTimeOfOrder = Convert.ToDateTime("2000-12-31"), Price = 1, Quantity = 1 };

            // Act & Assert
            var sellOrderResponse = _stocksService.CreateSellOrder(sellOrderRequest);

            Assert.NotEqual(Guid.Empty, sellOrderResponse.SellOrderID);
        }
        #endregion

        #region GetBuyOrders Tests
        // Add tests for GetBuyOrders here
        #endregion

        #region GetSellOrders Tests
        // Add tests for GetSellOrders here
        #endregion
    }
}