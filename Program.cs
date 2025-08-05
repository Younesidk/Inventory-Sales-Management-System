using Inventory___Sales_Management_System.Models;
using Inventory___Sales_Management_System.Services;

namespace Inventory_And_Sales_Management_System
{
    class Program
    {
        static void Main()
        {
            InventoryManager inventory = new InventoryManager();
            SalesManager salesManager = new SalesManager();

            DataService.LoadProductsFromJson(inventory);
            DataService.LoadSalesFromJson(salesManager);

            int MaxChoice = 7;

            while (true)
            {
                //Console.Clear();
                MainMenu();

                int Choice = 0;
                while (!int.TryParse(Console.ReadLine(), out Choice) || Choice < 0 || Choice > MaxChoice)
                    Console.WriteLine("\nPlease Respect The Menu");

                Console.Clear();

                switch (Choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Adding a Product\n");
                            string Name = EnterValidString("Enter the Name");

                            double Price = EnterValidNumberDouble("Enter the price per unit :");

                            int QuantityInStock = EnterValidNumberInt("Enter the Quantity In the Stock : ");

                            Console.WriteLine("Enter the Category : (Food = 1, Media = 2, Toys = 3, Clothing = 4)");
                            int Category = 0;
                            while(!int.TryParse(Console.ReadLine(),out Category) || !Enum.IsDefined(typeof(Product.ProductCategory),Category))
                                Console.WriteLine("Please Enter a Number and Respect the Boundries");

                            inventory.AddProduct(Name, Price, QuantityInStock, (Product.ProductCategory)Category);

                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Removing a Product\n");
                            string Name = EnterValidString("Enter the Name of the Product you want to remove : ");

                            inventory.RemoveProduct(inventory.GetProduct(Name));

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Searching for a Product\n");

                            string Name = EnterValidString("Enter the Name of the Product");
                            inventory.SearchProduct(Name);

                            break;
                        }
                    case 4:
                        {
                            inventory.ShowLowStockProduct();
                            break;
                        }
                    case 5:
                        {
                            inventory.ShowAllProducts();
                            break;
                        }
                    case 6:
                        {
                            inventory.ShowAllProducts();
                            Console.WriteLine();

                            string Name = EnterValidString("What Product you want to sell ?");

                            int Quantity = EnterValidNumberInt("How Much of the Product were bought ?");

                            int SaleID = EnterValidNumberInt("Enter the Sale ID");

                            salesManager.CreateSale(inventory.GetProduct(Name), inventory, Quantity, SaleID);

                            break;
                        }
                    case 7:
                        {
                            salesManager.ShowSales();
                            break;
                        }
                    case 0:
                        {
                            DataService.SaveProductsToJson(inventory);
                            DataService.SaveSalesToJson(salesManager);

                            Console.WriteLine("See you Soon !");
                            return;
                        }
                }

                Console.WriteLine();
            }
        }
        static void MainMenu()
        {
            Console.WriteLine("1.Add Product\n" +
                "2.Remove Product\n" +
                "3.Search For Product\n" +
                "4.Show Products that are low on stock\n" +
                "5.Show All Products\n" +
                "6.Make a Sale\n" +
                "7.Show All Sales\n" +
                "0.Exit");
        }

        static string EnterValidString(string Message)
        {
            Console.WriteLine(Message);
            string Text = Console.ReadLine();
            while ((string.IsNullOrEmpty(Text) || string.IsNullOrEmpty(Text)))
            {
                Console.WriteLine("Please Enter a Valid String");
                Text = Console.ReadLine();
            }

            return Text;
        }

        static int EnterValidNumberInt(string Message)
        {
            Console.WriteLine(Message);
            int number = 0;
            while(!int.TryParse(Console.ReadLine(),out number) || number < 0)
                Console.WriteLine("Please Enter a valid Input");

            return number;
        }
        static double EnterValidNumberDouble(string Message)
        {
            Console.WriteLine(Message);
            double number = 0;
            while (!double.TryParse(Console.ReadLine(), out number) || number < 0)
                Console.WriteLine("Please Enter a valid Input");

            return number;
        }

    }
}