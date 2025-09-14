using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstDemo.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new List<Course>();
        }

        public int StudentID { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        
        public virtual Grade? Grade { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
    
    public class Grade
    {
        public Grade()
        {
            Students = new List<Student>();
        }

        public int GradeId { get; set; }
        public string? GradeName { get; set; }
        public string? Section { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
    }
    
    public class Course
    {
        public Course()
        {
            Students = new List<Student>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
    }
} 