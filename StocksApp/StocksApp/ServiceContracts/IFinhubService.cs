namespace StocksApp.ServiceContracts
{
    public interface IFinhubService
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string symbol);
        Task<Dictionary<string, object>?> GetCompanyProfile(string symbol);
    }
}
