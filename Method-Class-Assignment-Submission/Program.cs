using System;

namespace MathMethodClass
{
    // This class contains a method to process two integer numbers
    class NumberProcessor
    {
        // This method performs a math operation on the first parameter
        // and displays the second parameter to the console
        public void ProcessNumbers(int firstNumber, int secondNumber)
        {
            // Multiply the first number by 2 and store the result
            int result = firstNumber * 2;
            
            // Display the result of the math operation
            Console.WriteLine($"Math operation result: {firstNumber} * 2 = {result}");
            
            // Display the second number to the screen
            Console.WriteLine($"Second number is: {secondNumber}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Display the title of the console application
            Console.WriteLine("Math Method Class Demo");
            Console.WriteLine("----------------------");
            
            // Instantiate the NumberProcessor class
            NumberProcessor processor = new NumberProcessor();
            
            // Call the method passing two numbers directly
            Console.WriteLine("\nCalling method with positional parameters:");
            processor.ProcessNumbers(5, 10);
            
            // Call the method specifying the parameters by name
            Console.WriteLine("\nCalling method with named parameters:");
            processor.ProcessNumbers(firstNumber: 7, secondNumber: 14);
            
            // Wait for user input before closing the console window
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
} 