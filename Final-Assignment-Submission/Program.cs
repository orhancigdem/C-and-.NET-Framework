using System;
using System.Collections.Generic;
using CodeFirstDemo.Data;
using CodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Code First Example - Student Databases");
            
            // Student information (single database)
            var studentInfos = new List<StudentInfo>
            {
                new StudentInfo {
                    Name = "Ahmet Yılmaz",
                    DateOfBirth = new DateTime(2002, 5, 10),
                    Height = 178.4m,
                    Weight = 72.5f,
                    Department = "Bilgisayar Mühendisliği",
                    Section = "Yapay Zeka",
                    Courses = new List<string> { "Veri Yapıları", "Makine Öğrenmesi", "Veritabanı Sistemleri" }
                }
            };
            
            // First delete all existing databases directly with SQL
            Console.WriteLine("\nDeleting existing databases...");
            DropAllDatabases(studentInfos);
            
            // Create separate database for each student
            foreach (var studentInfo in studentInfos)
            {
                Console.WriteLine($"\nCreating database for {studentInfo.Name}...");
                CreateDatabaseForStudent(studentInfo);
            }
            
            Console.WriteLine("\nDatabases successfully created for all students!");
            Console.WriteLine("Created databases:");
            
            foreach (var studentInfo in studentInfos)
            {
                Console.WriteLine($"- SchoolDB_{studentInfo.Name.Replace(" ", "_")}");
            }
        }
        
        // Student information class
        class StudentInfo
        {
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
            public decimal Height { get; set; }
            public float Weight { get; set; }
            public string Department { get; set; }
            public string Section { get; set; }
            public List<string> Courses { get; set; }
        }
        
        static void DropAllDatabases(List<StudentInfo> studentInfos)
        {
            string masterConnectionString = @"Server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=True;";
            
            using (var connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();
                
                foreach (var studentInfo in studentInfos)
                {
                    string dbName = $"SchoolDB_{studentInfo.Name.Replace(" ", "_")}";
                    
                    try
                    {
                        // DROP DATABASE IF EXISTS command
                        string dropCommand = $@"
                            IF EXISTS (SELECT name FROM sys.databases WHERE name = '{dbName}')
                            BEGIN
                                ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                                DROP DATABASE [{dbName}];
                            END";
                        
                        using (var command = new SqlCommand(dropCommand, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine($"  Deleted database: {dbName}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"  Failed to delete database {dbName}: {ex.Message}");
                    }
                }
                
            }
        }
        
        static void CreateDatabaseForStudent(StudentInfo studentInfo)
        {
            try
            {
                using (var context = new SchoolContext(studentInfo.Name))
                {
                    // Create database
                    context.Database.EnsureCreated();
                    
                    // Add a new Grade
                    var grade = new Grade
                    {
                        GradeName = studentInfo.Department,
                        Section = studentInfo.Section
                    };
                    context.Grades.Add(grade);
                    
                    // Add courses
                    var courses = new List<Course>();
                    foreach (var courseName in studentInfo.Courses)
                    {
                        var course = new Course { CourseName = courseName };
                        courses.Add(course);
                        context.Courses.Add(course);
                    }
                    
                    // Add student information
                    var student = new Student
                    {
                        Name = studentInfo.Name,
                        DateOfBirth = studentInfo.DateOfBirth,
                        Height = studentInfo.Height,
                        Weight = studentInfo.Weight,
                        Grade = grade
                    };
                    
                    // Add courses to student
                    foreach (var course in courses)
                    {
                        student.Courses.Add(course);
                    }
                    
                    context.Students.Add(student);
                    
                    // Save changes
                    context.SaveChanges();
                    
                    Console.WriteLine($"  Student saved: {student.StudentID} - {student.Name}");
                    Console.WriteLine($"  Department: {grade.GradeName} - {grade.Section}");
                    Console.WriteLine($"  Courses: {string.Join(", ", studentInfo.Courses)}");
                    Console.WriteLine($"  Date of Birth: {student.DateOfBirth.ToShortDateString()}");
                    Console.WriteLine($"  Height: {student.Height}cm, Weight: {student.Weight}kg");
                    Console.WriteLine($"  Database: SchoolDB_{studentInfo.Name.Replace(" ", "_")}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  Failed to create database for {studentInfo.Name}: {ex.Message}");
            }
        }
    }
}

