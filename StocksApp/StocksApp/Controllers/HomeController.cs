using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnhubServices _finnhubServices;
        private readonly IOptions<TradingOptions> _tradingOptions;

        public HomeController(FinnhubServices finnhubServices, IOptions<TradingOptions> tradingOptions)
        {
            _finnhubServices = finnhubServices;
            _tradingOptions = tradingOptions;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "MSFT";
            }

            Dictionary<string, object>? responseDictionary = await _finnhubServices.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);

            Stock stock = new Stock
            {
                StockSymbol = _tradingOptions.Value.DefaultStockSymbol,
                CurrentPrice = Convert.ToDouble(responseDictionary["c"].ToString()),
                LowestPrice = Convert.ToDouble(responseDictionary["l"].ToString()),
                HighestPrice = Convert.ToDouble(responseDictionary["h"].ToString()),
                OpenPrice = Convert.ToDouble(responseDictionary["o"].ToString())
            };

            return View(stock);
        }
    }
}
