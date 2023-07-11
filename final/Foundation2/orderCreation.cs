using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a customer
        Address customerAddress = new Address("123 Main St", "Cityville", "State A", "USA");
        Customer customer = new Customer("John Doe", customerAddress);

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

    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _products = new List<Product>();
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public float CalculateTotalCost()
        {
            float totalCost = 0;
            foreach (Product product in _products)
            {
                totalCost += product.Price * product.Quantity;
            }

            totalCost += _customer.IsInUSA() ? 5 : 35;

            return totalCost;
        }

        public string GetPackingLabel()
        {
            string packingLabel = "Packing Label:\n";
            foreach (Product product in _products)
            {
                packingLabel += $"Name: {product.Name}, Product ID: {product.ProductId}\n";
            }

            return packingLabel;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\nName: {_customer.Name}\nAddress: {_customer.Address.GetFullAddress()}";
        }
    }

    public class Product
    {
        private string _name;
        private string _productId;
        private float _price;
        private int _quantity;

        public Product(string name, string productId, float price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }

    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public bool IsInUSA()
        {
            return _address.IsInUSA();
        }
    }

    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _stateProvince;
        private string _country;

        public Address(string streetAddress, string city, string stateProvince, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _stateProvince = stateProvince;
            _country = country;
        }

        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string StateProvince
        {
            get { return _stateProvince; }
            set { _stateProvince = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public bool IsInUSA()
        {
            return _country == "USA";
        }

        public string GetFullAddress()
        {
            return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
        }
    }
}
