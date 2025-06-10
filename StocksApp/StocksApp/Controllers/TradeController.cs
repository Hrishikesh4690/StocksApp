using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.ServiceContracts;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class TradeController : Controller
    {
        private readonly IFinhubService _finnhubServices;
        private readonly TradingOptions _tradingOptions;
        private readonly IConfiguration _configuration;
        private readonly IStocksService _stocksService;

        public TradeController(IFinhubService finnhubServices, IOptions<TradingOptions> tradingOptions, IConfiguration configuration,IStocksService stocksService)
        {
            _finnhubServices = finnhubServices;
            _tradingOptions = tradingOptions.Value;
            _configuration = configuration;
            _stocksService = stocksService;
        }
        [Route("/")]
        [Route("[action]")]
        [Route("~/[controller]")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.DefaultStockSymbol == null)
            {
                _tradingOptions.DefaultStockSymbol = "MSFT";
            }

            Dictionary<string, object>? companyProfileDictionary = await _finnhubServices.GetCompanyProfile(_tradingOptions.DefaultStockSymbol);

            Dictionary<string, object>? stockQuoteDictionary = await _finnhubServices.GetStockPriceQuote(_tradingOptions.DefaultStockSymbol);

            StockTrade stockTrade = new StockTrade()
            {
                StockSymbol = _tradingOptions.DefaultStockSymbol,
            };
            
            if (companyProfileDictionary != null && stockQuoteDictionary != null)
            {
                stockTrade = new StockTrade()
                {
                    StockSymbol = Convert.ToString(companyProfileDictionary["ticker"]),
                    StockName = Convert.ToString(companyProfileDictionary["name"]),
                    Price = Convert.ToDouble(stockQuoteDictionary["c"].ToString())
                };
            }

            ViewBag.FinnhubToken = _configuration["FinnhubToken"];
            return View(stockTrade);
        }
    }
}
