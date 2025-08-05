using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory___Sales_Management_System.Models;


namespace Inventory___Sales_Management_System.Services
{
    internal class SalesManager
    {
        public List<Sale> sales = new List<Sale>();
        private double TotalRevenue = 0;

        public void CreateSale(Product product,InventoryManager manager,int Quantity,int SaleID)
        {
            if(!manager.IsProductAvailable(product))
            {
                Console.WriteLine("Product is not available , can't make the sale");
                return;
            }

            if (Quantity > product.QuantityInStock)
            {
                Console.WriteLine("Insuffisant Quantity , can't make the sale");
                return;
            }

            sales.Add(new Sale(product, Quantity, product.Price * Quantity, SaleID, DateTime.Now));
            product.QuantityInStock -= Quantity;
            TotalRevenue += Quantity * product.Price;
            Console.WriteLine("Sale was Done !!");
        }

        public void ShowSales()
        {
            if (sales.Count == 0)
            {
                Console.WriteLine("No Sales have been made yet");
                return;
            }

            Console.WriteLine("All Sales :");

            foreach (var sale in sales)
            {
                Console.WriteLine(sale);
            }
        }

        public double totalRevenue => TotalRevenue;
    }
}
