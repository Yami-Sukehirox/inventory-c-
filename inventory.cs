using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;

class Inventory
{

    class Product
    {
        public int productId;
        public string productName;
        public decimal price;
        public int quantity;
    }
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        Product keyboard = new Product()
        {
            productId = 1,
            productName = "Keyboard",
            price = 49.99m,
            quantity = 50
        };

        Console.WriteLine("Product Details:");
        Console.WriteLine($"Product ID: {keyboard.productId}");
        Console.WriteLine($"Product Name: {keyboard.productName}");
        Console.WriteLine($"Price: ${keyboard.price}");
        Console.WriteLine($"Quantity: {keyboard.quantity}");

        Product mouse = new Product()
        {
            productId = 2,
            productName = "Mouse",
            price = 29.99m,
            quantity = 100
        };

        Console.WriteLine("Product Details:");
        Console.WriteLine($"Product ID: {mouse.productId}");
        Console.WriteLine($"Product Name: {mouse.productName}");
        Console.WriteLine($"Price: ${mouse.price}");
        Console.WriteLine($"Quantity: {mouse.quantity}");


        int choice = 0;

        while(choice != 7)
        {
            Console.WriteLine("\nInventory Menu:");
            Console.WriteLine("1. Add New Product");
            Console.WriteLine("2. View Product Details");
            Console.WriteLine("3. Search Products");
            Console.WriteLine("4. Update Products");
            Console.WriteLine("5. Delete Products");
            Console.WriteLine("6. Calculate inventory value");
            Console.WriteLine("7. Exit");

            Console.Write("Please select an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Product newProduct = new();

                    Console.Write("Enter Product ID: ");
                    newProduct.productId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Product Name: ");
                    newProduct.productName = Console.ReadLine();

                    Console.Write("Enter Product Price: ");
                    newProduct.price = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter Product Quantity: ");
                    newProduct.quantity = int.Parse(Console.ReadLine());

                    prouduts.Add(newProduct);
                    Console.WriteLine("Product Sucessfully added!");

                    break;

                case 2:
                    Console.WriteLine("\n----PRODUCTS LIST------");

                    foreach (Product product in products)
                    {
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Product ID: {product.productId}");
                        Console.WriteLine($"Product Name: {product.productName}");
                        Console.WriteLine($"Product Price: {product.price}");
                        Console.WriteLine($"Product Quantity: {product.quantity}");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter Product ID to search: ");
                    int searchId = int.Parse(Console.ReadLine());

                    bool found = false;

                    foreach (Product product in products)
                    {
                        if (product.productId == searchId)
                        {
                            Console.WriteLine("\nProduct Found");
                            Console.WriteLine($"ID: {product.productId}");
                            Console.WriteLine($"Product Name: {product.productName}");
                            Console.WriteLine($"Product Price: {product.price}");
                            Console.WriteLine($"Product Quantity: {product.quantity}");

                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                    {
                        Console.WriteLine("Product not found");
                    }
                    break;
                    
                case 4:
                    Console.WriteLine("-------UPDATE A PRODUCT--------");
                    int updateId = int.Parse(Console.ReadLine());

                    bool found = false;

                    foreach (Product product in products)
                    {
                        if(product.productId == updateId)
                        {
                            Console.WriteLine("Enter New Product Name: ");
                            product.productName = Console.ReadLine();

                            Console.WriteLine("Enter New Product Price: ");
                            product.price = decimal.Parse(Console.ReadLine);

                            Console.WriteLine("Enter New Product Quantity: ");
                            product.quantity = int.Parse(Console.ReadLine());

                            Console.WriteLine("Product Successfully Updated!");

                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                    {
                        Console.WriteLine("Product Not Found!");
                    }
                    break;

                case 5:
                    // delete
                    break;

                case 6:
                    // calculate 
                    break;
                
                case 7:
                    // Exit
                    break;


                default:
                    Console.WriteLine("Invalid choice!");
                    break;        
            }                            
        }
    }
}