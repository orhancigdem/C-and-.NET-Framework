using System;
using System.ComponentModel.DataAnnotations;

namespace car.Models
{
    public class Insuree
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        [Required]
        [Display(Name = "Car Make")]
        public string CarMake { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Speeding Tickets")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int SpeedingTickets { get; set; }

        [Required]
        [Display(Name = "Have you ever had a DUI?")]
        public bool DUI { get; set; }

        [Required]
        [Display(Name = "Full Coverage")]
        public bool FullCoverage { get; set; }

        public decimal Quote { get; set; }
    }
} 