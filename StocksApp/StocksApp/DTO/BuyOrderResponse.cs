using System.ComponentModel.DataAnnotations;

namespace StocksApp.DTO
{
    public class BuyOrderResponse
    {
        public Guid BuyOrderId { get; set; }
        public string StockSymbol { get; set; }
        [Required(ErrorMessage = "Stock Name can't be null or empty")]
        public string StockName { get; set; }
        public DateTime DateTimeOfOrder { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; set; }
        public double TradeAmount { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (obj is not BuyOrderResponse)
                return false;
            BuyOrderResponse other = (BuyOrderResponse)obj;

            return BuyOrderId == other.BuyOrderId &&
                   StockSymbol == other.StockSymbol &&
                   StockName == other.StockName &&
                   DateTimeOfOrder == other.DateTimeOfOrder &&
                   Quantity == other.Quantity &&
                   Price == other.Price;
        }

        public override string ToString()
        {
            return $"Buy Order Id: {BuyOrderId}, Stock Symbol: {StockSymbol}, Stock Name: {StockName}, Date and Time of Order: {DateTimeOfOrder.ToString("dd MMM yyyy hh:mm ss tt")}, Quantity: {Quantity}, Price: {Price}, Trade Amount: {TradeAmount}";
        }

        public override int GetHashCode()
        {
            return StockSymbol.GetHashCode();
        }
    }
}
