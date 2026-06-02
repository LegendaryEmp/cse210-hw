using System;

class Program
{
    static void Main(string[] args)
    {
        Address firstAddress = new Address("145 Lakeview Drive", "Boise", "ID", "USA");
        Customer firstCustomer = new Customer("Elena Ramirez", firstAddress);
        Order firstOrder = new Order(firstCustomer);
        firstOrder.AddProduct(new Product("Wireless Mouse", "WM-204", 24.99, 2));
        firstOrder.AddProduct(new Product("Laptop Stand", "LS-317", 39.50, 1));
        firstOrder.AddProduct(new Product("USB-C Cable", "UC-108", 9.75, 3));

        Address secondAddress = new Address("28 King Street", "Toronto", "ON", "Canada");
        Customer secondCustomer = new Customer("Daniel Chen", secondAddress);
        Order secondOrder = new Order(secondCustomer);
        secondOrder.AddProduct(new Product("Desk Lamp", "DL-512", 31.25, 1));
        secondOrder.AddProduct(new Product("Notebook Set", "NS-625", 12.40, 2));

        DisplayOrder(firstOrder);
        DisplayOrder(secondOrder);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
        Console.WriteLine();
    }
}
