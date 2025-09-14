// Employee class - Contains Id, FirstName and LastName properties and overloads equality operators
using System;

namespace OperatorsAssignment
{
    /// <summary>
    /// Employee class contains employee information and comparison operators.
    /// </summary>
    public class Employee
    {
        // Employee properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Overloading the "==" operator - compares Id values of two employees
        public static bool operator ==(Employee employee1, Employee employee2)
        {
            // If both references are null, they are equal
            if (ReferenceEquals(employee1, null) && ReferenceEquals(employee2, null))
                return true;

            // If one of the references is null, they are not equal
            if (ReferenceEquals(employee1, null) || ReferenceEquals(employee2, null))
                return false;

            // Compare Id values
            return employee1.Id == employee2.Id;
        }

        // Overloading the "!=" operator - operators must be overloaded in pairs
        public static bool operator !=(Employee employee1, Employee employee2)
        {
            // Return the negation of the "==" operator result
            return !(employee1 == employee2);
        }

        // Override Object.Equals method - good practice
        public override bool Equals(object obj)
        {
            // Return false if parameter is null or wrong type
            if (obj == null || !(obj is Employee))
                return false;

            // Compare using the "==" operator
            return this == (Employee)obj;
        }

        // Override Object.GetHashCode method - required when Equals is overridden
        public override int GetHashCode()
        {
            // Return hash code based on Id property
            return Id.GetHashCode();
        }
    }
} 