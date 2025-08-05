using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory___Sales_Management_System.Models
{
    internal class Sale
    {
        public Product ProductsSold { get; set; }
        public int QuantitySold { get; set; }
        public double PriceGot { get; set; }
        public int SaleID { get; set; }
        public DateTime Date { get; set; }

        public Sale(Product productsSold, int QuantitySold, double PriceGot, int saleID, DateTime date)
        {
            ProductsSold = productsSold;
            this.QuantitySold = QuantitySold;
            this.PriceGot = PriceGot;
            SaleID = saleID;
            Date = date;
        }

        public override string ToString()
        {
            return $"Product {ProductsSold.Name} was sold on {Date} ,{QuantitySold} Units were Sold ,Money Gained was {PriceGot} DA, with sale ID {SaleID}";
        }
    }
}
