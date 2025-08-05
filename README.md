# Inventory Sales Management System

A simple C# console application for managing inventory and sales of products. The system allows users to efficiently track products, manage stock, and record sales transactions.

## Features

- **Add Product**: Add new products with name, price, quantity, and category (Food, Media, Toys, Clothing).
- **Remove Product**: Delete products from the inventory.
- **Search Product**: Find products by name.
- **Show Low Stock Products**: Display products with quantity less than 5.
- **Show All Products**: View all products currently in stock.
- **Make a Sale**: Record a sale, update inventory, and calculate total revenue.
- **Show All Sales**: List all sales transactions with details.

## Data Persistence

- Products and sales are saved to JSON files (`products.json`, `sales.json`) for persistence between sessions.

## Getting Started

1. **Clone the repository**
   ```sh
   git clone https://github.com/Younesidk/Inventory-Sales-Management-System.git
   ```

2. **Open the project in Visual Studio or your preferred IDE**

3. **Build and Run**
   - Start the application. The main menu will appear in the console.

## Usage

Follow the console prompts to manage the inventory and sales:

```
1. Add Product
2. Remove Product
3. Search For Product
4. Show Products that are low on stock
5. Show All Products
6. Make a Sale
7. Show All Sales
0. Exit
```

## Product Categories

- **Food**
- **Media**
- **Toys**
- **Clothing**

## Data Structure

- **Product**: ID, Name, Price, QuantityInStock, Category
- **Sale**: ProductsSold, QuantitySold, PriceGot, SaleID, Date

## Example Sale Transaction

When making a sale, the system checks for product availability and sufficient stock. If successful, it records the sale, updates the inventory, and adds to total revenue.

## Saving and Loading

- Data is automatically loaded from JSON files at startup and saved on exit.

## Requirements

- .NET Core or .NET Framework compatible with C# 10+
- Console application environment

## License

MIT

## Author

[Younesidk](https://github.com/Younesidk)
