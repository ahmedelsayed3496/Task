using BikeStores.Data;
using BikeStores.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BikeStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            var categories = dbContext.Categories.ToList();

            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryName}");
            }

            Console.WriteLine("-----------------");


            var firstProduct = dbContext.Products.FirstOrDefault();
            Console.WriteLine($"First Product: {firstProduct.ProductName}");

            Console.WriteLine("-----------------");

            var Product = dbContext.Products.Find(5);
            Console.WriteLine($"the prodect is: {Product.ProductName}");

            Console.WriteLine("-----------------");

            var productsByYear = dbContext.Products.Where(e => e.ModelYear == 2016).ToList();

            foreach (var product in productsByYear)
            {
                Console.WriteLine($"{product.ProductName}");
            }

            Console.WriteLine("-----------------");

            var customer = dbContext.Customers.Find(10);
            Console.WriteLine($"the customer is: {customer.FirstName} {customer.LastName}");

            Console.WriteLine("-----------------");

            var listOfProducts = dbContext.Products.Include(e => e.Brand).Select(e => new { e.ProductName, e.Brand.BrandName }).ToList();

            foreach (var item in listOfProducts)
            {
                Console.WriteLine($"Product name:{item.ProductName}, Brand name: ({item.BrandName})");
            }
            Console.WriteLine("-----------------");

            var productCount = dbContext.Products.Count(e => e.CategoryId == 1);
            Console.WriteLine($"The count of product: {productCount}");
            
            Console.WriteLine("-----------------");

            var totalListPrice = dbContext.Products.Where(e => e.CategoryId == 1).Sum(e => e.ListPrice);
            Console.WriteLine($"The total: {totalListPrice}");
            Console.WriteLine("-----------------");

            var avgListPrice = dbContext.Products.Average(e => e.ListPrice);
            Console.WriteLine($"The average is: {avgListPrice}");
            Console.WriteLine("-----------------");

            var completedOrders = dbContext.Orders.Where(e => e.OrderStatus == 4).ToList();
           
            foreach (var order in completedOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}");
            }
        }

    }
    
}
    

