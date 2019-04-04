using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage((thisStorage, thisProduct, path) =>
            {
                thisStorage.products.Add(thisProduct);
                thisStorage.Save(path);
                System.Console.WriteLine("The product is added");
            });

            string filePath = "storage.xml";

            while (true)
            {
                while (true)
                {
                    System.Console.WriteLine("Do you wanna add a product?\n1 - yes\n0 - no");
                    int answer = int.Parse(System.Console.ReadLine());
                    if (answer == 1)
                        break;
                    else if (answer == 0)
                        Environment.Exit(1);
                    else
                        System.Console.WriteLine("Your answer is incorrect");
                }
                Product product = new Product();

                while (true)
                {
                    System.Console.Write("Enter name: ");
                    product.Name = System.Console.ReadLine();
                    if (product.Name == "")
                    {
                        System.Console.WriteLine("You didn't entered the name:0");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    System.Console.Write("Enter name of manufacturer: ");
                    product.Manufacturer = System.Console.ReadLine();
                    if (product.Manufacturer == "")
                    {
                        System.Console.WriteLine("You didn't entered the name:0");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    System.Console.Write("Enter the count of products: ");
                    product.Count = int.Parse(System.Console.ReadLine());
                    if (product.Count <= 0)
                    {
                        System.Console.WriteLine("This is an incorrect number");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    System.Console.WriteLine("Is this product imported? (true or false)");
                    string testValue = System.Console.ReadLine();
                    if (testValue != "true" && testValue != "false")
                    {
                        System.Console.WriteLine("Hmmm... This isn't true or false");
                        continue;
                    }
                    product.IsImported = bool.Parse(testValue);
                    break;
                }

                while (true)
                {
                    try
                    {
                        System.Console.WriteLine("Enter expiration date: ");
                        product.ExpirationDate = DateTime.Parse(System.Console.ReadLine());
                    }
                    catch (FormatException exception)
                    {
                        System.Console.WriteLine("Incorrect date format");
                        continue;
                    }
                    catch (Exception exception)
                    {
                        System.Console.WriteLine("Something went wrong:(");
                        continue;
                    }
                    if (product.ExpirationDate < DateTime.Now)
                    {
                        System.Console.WriteLine("Too small date");
                        continue;
                    }
                    break;
                }

                System.Console.WriteLine("Press ENTER to add a product");
                System.Console.ReadLine();

                storage.AddProduct(product, filePath);
            }
        }
    }
}
