using System;
using System.ComponentModel.DataAnnotations;

namespace AppUtility.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }
    }
    
}
