// This is the entry point of our application

using System;

class Program
{
    // Main method - the application starts here
    static void Main(string[] args)
    {
        // Create an instance of Employee
        Employee employee = new Employee("John", "Doe", 12345);
        
        // Call Quit method directly on Employee instance
        employee.Quit();
        
        // Using polymorphism: Create an object of type IQuittable (interface)
        // but instantiate it as an Employee (which implements the interface)
        IQuittable quittableEmployee = new Employee("Jane", "Smith", 67890);
        
        // Call the Quit method through the interface reference
        // This demonstrates polymorphism - calling the same method through different types
        quittableEmployee.Quit();
        
        // Wait for user input before closing
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
} 