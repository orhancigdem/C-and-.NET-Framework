// Program.cs - Examples of Employee class and operator overloading
using System;

namespace OperatorsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two Employee objects
            Employee employee1 = new Employee
            {
                Id = 101,
                FirstName = "John",
                LastName = "Smith"
            };

            Employee employee2 = new Employee
            {
                Id = 102,
                FirstName = "Jane",
                LastName = "Doe"
            };

            // Display employee information
            Console.WriteLine("Employee 1: Id = {0}, Name = {1} {2}", 
                employee1.Id, employee1.FirstName, employee1.LastName);
            Console.WriteLine("Employee 2: Id = {0}, Name = {1} {2}", 
                employee2.Id, employee2.FirstName, employee2.LastName);
            
            Console.WriteLine();

            // Compare using the "==" operator
            Console.WriteLine("Comparing employees (different Ids):");
            Console.WriteLine("employee1 == employee2: {0}", employee1 == employee2);
            Console.WriteLine("employee1 != employee2: {0}", employee1 != employee2);
            
            Console.WriteLine();

            // Example of comparison with the same Id
            Employee employee3 = new Employee
            {
                Id = 101, // Same Id as employee1
                FirstName = "Alice",
                LastName = "Johnson"
            };

            Console.WriteLine("Employee 3: Id = {0}, Name = {1} {2}", 
                employee3.Id, employee3.FirstName, employee3.LastName);
            
            Console.WriteLine();

            // Compare using the "==" operator (same Ids)
            Console.WriteLine("Comparing employees (same Ids):");
            Console.WriteLine("employee1 == employee3: {0}", employee1 == employee3);
            Console.WriteLine("employee1 != employee3: {0}", employee1 != employee3);
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
