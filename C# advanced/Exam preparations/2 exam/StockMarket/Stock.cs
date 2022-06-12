using System.Text;
using System;
namespace StockMarket
{
    public class Stock
    {
        
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }
        public Stock(string companyName, string director, decimal pricePerShare, int totalShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalShares;
            MarketCapitalization = PricePerShare * TotalNumberOfShares;


        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Company: {CompanyName}").Append(Environment.NewLine);
            sb.Append($"Director: {Director}").Append(Environment.NewLine);
            sb.Append($"Price per share: ${PricePerShare}").Append(Environment.NewLine);
            sb.Append($"Market capitalization: ${MarketCapitalization}").Append(Environment.NewLine);
            return sb.ToString();

        }

    }
}
