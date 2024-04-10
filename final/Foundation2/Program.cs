using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public bool IsInUSA()
    {
        // Simplified logic, assumes any state code starting with "US" is in the USA
        return State.StartsWith("US");
    }
}

class Customer
{
    public string Name { get; set; }
    public Address ShippingAddress { get; set; }

    public Customer(string name, Address shippingAddress)
    {
        Name = name;
        ShippingAddress = shippingAddress;
    }
}

class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public Order(Customer customer)
    {
        Products = new List<Product>();
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (var product in Products)
        {
            total += product.Price;
        }
        return total;
    }

    public void GenerateShippingLabel()
    {
        Console.WriteLine("Shipping Label:");
        Console.WriteLine($"To: {Customer.Name}");
        Console.WriteLine($"Address: {Customer.ShippingAddress.Street}, {Customer.ShippingAddress.City}, {Customer.ShippingAddress.State}, {Customer.ShippingAddress.ZipCode}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a sample address
        Address address = new Address
        {
            Street = "123 Main St",
            City = "Anytown",
            State = "US-NY",
            ZipCode = "12345"
        };

        // Create a sample customer
        Customer customer = new Customer("John Doe", address);

        // Create an order
        Order order = new Order(customer);

        // Add products to the order
        order.AddProduct(new Product("Product 1", 10.99));
        order.AddProduct(new Product("Product 2", 5.99));
        order.AddProduct(new Product("Product 3", 7.49));

        // Calculate total cost
        double totalCost = order.CalculateTotalCost();
        Console.WriteLine($"Total Cost: ${totalCost}");

        // Generate shipping label
        order.GenerateShippingLabel();
    }
}
