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


        Product mouse = new Product()
        {
            productId = 2,
            productName = "Mouse",
            price = 29.99m,
            quantity = 100
        };

        products.Add(keyboard);
        products.Add(mouse);


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

            Console.WriteLine("SELECT YOU CHOICE");
           if(!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please Enter a valid number!");
                continue;
            }

            switch (choice)
            {
                case 1:
                {
                    Product newProduct = new();

                    Console.Write("Enter Product ID: ");
                    if (!int.TryParse(Console.ReadLine(), out newProduct.productId) || newProduct.productId <= 0)
                        {
                            Console.WriteLine("Invalid Product ID");
                            break;
                        }

                    Console.Write("Enter Product Name: ");
                    newProduct.productName = Console.ReadLine();

                    Console.Write("Enter Product Price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out newProduct.price) || newProduct.price < 0)
                        {
                            Console.WriteLine("Invalid Price");
                            break;
                        }

                    Console.Write("Enter Product Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out newProduct.quantity) || newProduct.quantity < 0)
                        {
                            Console.WriteLine("Invalid Quantity");
                            break;
                        }

                    // Check for duplicate Product ID
                    bool idExists = false;

                    foreach (Product product in products)
                    {
                        if (product.productId == newProduct.productId)
                        {
                            idExists = true;
                            break;
                        }
                    }

                    if (idExists)
                    {
                        Console.WriteLine("Product ID already exists!");
                        break;
                    }    

                    products.Add(newProduct);
                    Console.WriteLine("Product Sucess fully added!");

                    break;
                }
                case 2:
                {
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
                }    
               
                case 3:
                {
                    Console.WriteLine("\n===== SEARCH PRODUCT =====");
                    Console.WriteLine("1. Search by Product ID");
                    Console.WriteLine("2. Search by Product Name");
                    Console.WriteLine("3. Back to Main Menu");

                    Console.Write("Enter your choice: ");
                    int searchChoice = int.Parse(Console.ReadLine());

                    switch (searchChoice)
                        {
                            case 1:
                            {
                                Console.Write("Enter Product ID: ");

                                if (!int.TryParse(Console.ReadLine(), out int searchId))
                                {
                                    Console.WriteLine("Invalid Product ID");
                                    break;
                                }

                                bool found = false;

                                foreach (Product product in products)
                                {
                                    if (product.productId == searchId)
                                    {
                                        Console.WriteLine("\nProduct Found");
                                        Console.WriteLine($"Name: {product.productName}");
                                        Console.WriteLine($"Price: ${product.price}");
                                        Console.WriteLine($"Quantity: {product.quantity}");

                                        found = true;
                                        break;
                                    }
                                }

                                if (!found)
                                    {
                                        Console.WriteLine("Product not found");
                                    }
                                    break;
                                }   
                            case 2:
                                {
                                    Console.Write("Enter Product Name: ");
                                    
                                    string searchName = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(searchName))
                                        {
                                            Console.WriteLine("Product name cannot be empty!");
                                            break;
                                        }
                                    bool found = false;

                                    foreach (Product product in products)
                                    {
                                        if (product.productName == searchName.ToLower())
                                        {
                                            Console.WriteLine("\nProduct Found");
                                            Console.WriteLine($"ID: {product.productId}");
                                            Console.WriteLine($"Name: {product.productName}");
                                            Console.WriteLine($"Price: {product.price}");
                                            Console.WriteLine($"Quantity: {product.quantity}");

                                            found == true;
                                            break;
                                        }
                                    }

                                    if (!found)
                                    {
                                        Console.WriteLine("Product not found");
                                    }
                                    break;
                                }
                                
                            case 3:
                                Console.WriteLine("Back to main menu selected.");
                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;    
                        }
                    break;
                }
                case 4:
                {
                    Console.WriteLine("-------UPDATE A PRODUCT--------");
                    Console.Write("Enter Product ID: ");
                    int updateId = int.Parse(Console.ReadLine());

                    bool found = false;

                    foreach (Product product in products)
                    {
                        if(product.productId == updateId)
                        {
                            Console.WriteLine("Enter New Product Name: ");
                            product.productName = Console.ReadLine();

                            Console.WriteLine("Enter New Product Price: ");
                            product.price = decimal.Parse(Console.ReadLine());

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
                }
                case 5:
                {
                    Console.Write("Enter Product ID: ");
                    int deleteId = int.Parse(Console.ReadLine());

                    Product productToDelete = null;

                    foreach (Product product in products)
                    {
                        if (product.productId == deleteId)
                        {
                            productToDelete = product;
                            break;
                        }
                    }

                    if (productToDelete != null)
                    {
                        products.Remove(productToDelete);
                        Console.WriteLine("Product Sucessfully deleted!");
                    }
                    else
                    {
                        Console.WriteLine("Product ID not found");
                    }
                    break;
                }
                case 6:
                {
                    decimal totalValue = 0;

                    foreach (Product product in products)
                    {
                        totalValue += product.price * product.quantity;
                    }

                    Console.WriteLine("=========INVENTORY VALUE==========");
                    Console.WriteLine($"Total Inventory value: ${totalValue}");
                    break;
                }
                case 7:
                    Console.WriteLine("Exiting Inventory System..");
                    break;


                default:
                    Console.WriteLine("Invalid choice!");
                    break;        
            }                            
        }
    }
}