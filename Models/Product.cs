using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Inventory___Sales_Management_System.Models
{
    public class Product
    {
        public int ID { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException();
                name = value;
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                price = value;
            }
        }

        private int quantityinstock;
        public int QuantityInStock
        {
            get { return quantityinstock; }
            set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException();
                quantityinstock = value;
            }
        }
        public enum ProductCategory
        {
            Food = 1,
            Media = 2,
            Toys = 3,
            Clothing = 4
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductCategory Category { get; set; }


        public Product(string name, double price, int quantityinstock, ProductCategory category)
        {
            Name = name;
            Price = price;
            QuantityInStock = quantityinstock;
            Category = category;
        }

        public Product()
        {
        }

        public override string ToString()
        {
            return $"Name = {name}, Price = {price} DA, Quantity = {QuantityInStock} , Category = {Category}";
        }
    }
}