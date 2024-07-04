using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JsonManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"products.json";
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" },
                new Product { Id = 2, Name = "Smartphone", Price = 699.99m, Category = "Electronics" }
            };

            // Ghi danh sách sản phẩm vào tệp JSON
            WriteProductsToJson(filePath, products);
            Console.WriteLine("Products written to JSON file.");

            // Đọc danh sách sản phẩm từ tệp JSON
            List<Product> readProducts = ReadProductsFromJson(filePath);
            Console.WriteLine("Products read from JSON file:");

            foreach (var product in readProducts)
            {
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}, {product.Category}");
            }
        }

        public static void WriteProductsToJson(string filePath, List<Product> products)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(products, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<Product> ReadProductsFromJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Product>>(jsonString);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}