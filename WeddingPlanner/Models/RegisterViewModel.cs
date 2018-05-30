using System;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{
    // checks for a date that isn't behind the current date
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if(dt >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }

    public class RegisterViewUser : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be a name with letters")]
        [Display(Name ="First Name")]
        public string fName {get; set;}

        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be a name with letters")]
        [Display(Name ="Last Name")]
        public string lName {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email {get; set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password {get; set;}

        [Compare("Password", ErrorMessage="Passwords must match")]
        [DataType(DataType.Password)]
        public string cPassword {get; set;}

    }
    public class RegisterViewPlan : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be a name with letters")]
        [Display(Name ="Wedder One")]
        public string PersonOne {get; set;}

        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Must be a name with letters")]
        [Display(Name ="Wedder Two")]
        public string PersonTwo {get; set;}

        [Required]
        [CurrentDate]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Wedding")]
        public DateTime Date {get; set;}

        [Required]
        [Display(Name ="Wedding Address")]
        public string Address {get; set;}
    }

        public class LoginValidate : BaseEntity
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string lEmail {get; set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string lPassword {get; set;}

    }


}