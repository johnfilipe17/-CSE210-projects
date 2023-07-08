using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        products = new List<Product>();
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public float CalculateTotalCost()
    {
        float totalCost = 0;
        foreach (Product product in products)
        {
            totalCost += product.Price * product.Quantity;
        }

        totalCost += customer.IsInUSA() ? 5 : 35;

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in products)
        {
            packingLabel += $"Name: {product.Name}, Product ID: {product.ProductId}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nName: {customer.Name}\nAddress: {customer.Address.GetFullAddress()}";
    }
}

public class Product
{
    private string name;
    private string productId;
    private float price;
    private int quantity;

    public Product(string name, string productId, float price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public float Price
    {
        get { return price; }
        set { price = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

public class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public string StreetAddress
    {
        get { return streetAddress; }
        set { streetAddress = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string StateProvince
    {
        get { return stateProvince; }
        set { stateProvince = value; }
    }

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    public bool IsInUSA()
    {
        return country == "USA";
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateProvince}\n{country}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a customer
        Address customerAddress = new Address("123 Main St", "Cityville", "State A", "USA");
        Customer customer = new Customer("Jane Doe", customerAddress);

        // Create an order
        Order order = new Order(customer);

        // Add products to the order
        Product product1 = new Product("Product 1", "P1", 10.99f, 2);
        Product product2 = new Product("Product 2", "P2", 5.99f, 3);

        order.AddProduct(product1);
        order.AddProduct(product2);

        // Get and display the packing label
        string packingLabel = order.GetPackingLabel();
        Console.WriteLine(packingLabel);

        // Get and display the shipping label
        string shippingLabel = order.GetShippingLabel();
        Console.WriteLine(shippingLabel);

        // Calculate and display the total cost
        float totalCost = order.CalculateTotalCost();
        Console.WriteLine($"Total Cost: {totalCost}");

        // Wait for user input to exit
        Console.ReadLine();
    }