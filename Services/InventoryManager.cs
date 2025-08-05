using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory___Sales_Management_System.Models;

namespace Inventory___Sales_Management_System.Services
{
    internal class InventoryManager
    {
        public List<Product> products = new List<Product>();


        public void AddProduct(string Name, double Price, int QuantityInStock, Product.ProductCategory Category)
        {
            try
            {
                products.Add(new Product(Name, Price, QuantityInStock, Category));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Please Respect The Name Or Category");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Please Respect the Pricing or Quantity In Stock");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Exception : " + ex.Message);
            }
        }

        public void RemoveProduct(Product product)
        {
            if (products.Count < 0)
            {
                Console.WriteLine("The Stock is Empty");
                return;
            }

            if (!products.Contains(product))
            {
                Console.WriteLine("Product is not available , can't remove it");
                return;
            }

            products.Remove(product);
        }

        public void SearchProduct(string Name)
        {
            Product? Search = products.Find(n => n.Name == Name);

            if (Search == null)
            {
                Console.WriteLine("product was not found");
                return;
            }

            Console.WriteLine(Search);
        }

        public void ShowLowStockProduct()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("The stock is Empty");
                return;
            }

            Console.WriteLine("Products that are Low On Stock : ");

            foreach (var product in products)
            {
                if(product.QuantityInStock < 5)
                    Console.WriteLine(product);
            }
        }

        public void ShowAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("The Stock Is Empty");
                return;
            }

            Console.WriteLine("All Products in Stock : ");

            foreach(var product in products)
                Console.WriteLine(product);
        }

        public bool IsProductAvailable(Product product) => products.Contains(product);

        public Product? GetProduct(string Name) => products.Find(p => p.Name == Name);
        
    }
}
