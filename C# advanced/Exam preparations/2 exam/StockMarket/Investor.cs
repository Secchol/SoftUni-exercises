using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace StockMarket
{
    public class Investor
    {
        //•	FullName: string
        //•	EmailAddress: string
        //•	MoneyToInvest: decimal
        //•	BrokerName: string
        public Dictionary<string, Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get; private set; }
        public Investor(string fullName, string emailAdress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAdress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Count = 0;
            Portfolio = new Dictionary<string, Stock>();


        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock.CompanyName, stock);
                Count++;
            }


        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.ContainsKey(companyName))
                return $"{companyName} does not exist.";
            if (sellPrice < Portfolio[companyName].PricePerShare)
                return $"Cannot sell {companyName}.";
            Portfolio.Remove(companyName);
            this.MoneyToInvest += sellPrice;
            Count--;

            return $"{companyName} was sold.";

        }
        public Stock FindStock(string companyName)
        {
            Stock stock = Portfolio.Values.FirstOrDefault(x => x.CompanyName == companyName);
            return stock;


        }
        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count == 0)
                return null;
            Stock biggestCompany = null;
            decimal bestMarketCap = decimal.MinValue;
            foreach (Stock stock in Portfolio.Values)
            {
                if (stock.MarketCapitalization > bestMarketCap)
                {

                    bestMarketCap = stock.MarketCapitalization;
                    biggestCompany = stock;

                }


            }
            return biggestCompany;


        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (Stock stock in Portfolio.Values)
            {
                sb.Append(stock.ToString());


            }
            return sb.ToString().TrimEnd();



        }

    }
}
