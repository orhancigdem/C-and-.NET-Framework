// Employee.cs
// This file contains the Employee class which implements the IQuittable interface

using System;

// Employee class definition - inherits from IQuittable interface
public class Employee : IQuittable
{
    // Private fields to store employee data
    private string _firstName;
    private string _lastName;
    private int _id;

    // Constructor to initialize employee data
    public Employee(string firstName, string lastName, int id)
    {
        _firstName = firstName;
        _lastName = lastName;
        _id = id;
    }

    // Properties to access employee data
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    // Implementation of the Quit method from IQuittable interface
    public void Quit()
    {
        // Display a message when an employee quits
        Console.WriteLine($"Employee {_firstName} {_lastName} (ID: {_id}) has quit the company.");
        Console.WriteLine("Exit paperwork has been processed.");
    }
} 