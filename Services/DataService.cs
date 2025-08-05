using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Inventory___Sales_Management_System.Models;

namespace Inventory___Sales_Management_System.Services
{
    static internal class DataService
    {
        private const string ProductsJsonFilePath = "products.json";
        private const string SalesJsonFilePath = "sales.json";

        static public void SaveProductsToJson(InventoryManager inventory)
        {
            string jsonString = JsonSerializer.Serialize(inventory.products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ProductsJsonFilePath, jsonString);
        }
        static public void LoadProductsFromJson(InventoryManager inventory)
        {
            string jsonFromFile = File.ReadAllText(ProductsJsonFilePath);

            if (!string.IsNullOrWhiteSpace(jsonFromFile))
            {
                try
                {
                    var loaded = JsonSerializer.Deserialize<List<Product>>(jsonFromFile);
                    if (loaded != null)
                        inventory.products = loaded;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed To Load Products.");
                    Console.WriteLine("Error : " + ex.Message);
                }
            }

        }

        static public void SaveSalesToJson(SalesManager sales)
        {
            string jsonString = JsonSerializer.Serialize(sales.sales, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SalesJsonFilePath, jsonString);
        }
        static public void LoadSalesFromJson(SalesManager sales)
        {
            string JsonFromFile = File.ReadAllText(SalesJsonFilePath);

            if (!string.IsNullOrWhiteSpace(JsonFromFile))
            {
                try
                {
                    var loaded = JsonSerializer.Deserialize<List<Sale>>(JsonFromFile);
                    if (loaded != null)
                        sales.sales = loaded;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed To Load Sales");
                    Console.WriteLine($"Error : {ex.Message}");
                }
            }
        }
        
    }
}
