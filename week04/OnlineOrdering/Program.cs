using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("45 Queen St", "Toronto", "ON", "Canada");
        Customer customer1 = new Customer("Maria Lopez", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Phone", "P308", 700, 1));
        order1.AddProduct(new Product("Headphones", "P490", 100, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        Address address2 = new Address("Cr 123: 1-5", "San Gil", "Santander", "Colombia");
        Customer customer2 = new Customer("Jose Castro", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Laptop", "P100", 900, 1));
        order2.AddProduct(new Product("Backpack", "B432", 30.50, 1));
        order2.AddProduct(new Product("Mouse", "P209", 25, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}\n");
    }
}