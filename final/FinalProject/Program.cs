using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public double TotalCost => Price * Quantity;
}

public class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public bool IsInUSA() => Country == "USA";

    public override string ToString()
    {
        return $"{StreetAddress}, {City}, {State}, {Country}";
    }
}

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA() => Address.IsInUSA();
}

public class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (Product product in Products)
        {
            totalCost += product.TotalCost;
        }

        return totalCost + (Customer.IsInUSA() ? 5 : 35);
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in Products)
        {
            packingLabel += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return Customer.Address.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address = new Address { StreetAddress = "123 Main St", City = "Anytown", State = "CA", Country = "USA" };
        Customer customer = new Customer("John Doe", address);

        List<Product> products = new List<Product>
        {
            new Product { Name = "Product 1", ProductId = 1, Price = 10.99, Quantity = 2 },
            new Product { Name = "Product 2", ProductId = 2, Price = 19.99, Quantity = 1 }
        };

        Order order = new Order(products, customer);

        Console.WriteLine($"Packing Label:\n{order.GetPackingLabel()}\n");
        Console.WriteLine($"Shipping Label:\n{order.GetShippingLabel()}\n");
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost()}\n");
    }
}