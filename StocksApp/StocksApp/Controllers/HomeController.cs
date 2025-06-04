using Microsoft.AspNetCore.Mvc;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnhubServices _finnhubServices;
        
        public HomeController(FinnhubServices finnhubServices)
        {
            _finnhubServices = finnhubServices;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object>? responseDictionary = await _finnhubServices.GetStockPriceQuote("MSFT");
            return View();
        }
    }
}
