using System;
using System.ComponentModel.DataAnnotations;

namespace Banker.Models{
    public class RegisterViewModel:BaseEntity{

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name ="First Name")]

        public string fname {get; set;}
        
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name ="Last Name")]
        public string lname{get; set;}

        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string email {get; set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password {get; set;}

        [Compare("password", ErrorMessage ="Password and Confrimation Password must match!")]
        public string cpassword {get; set;}

    }

    public class LoginViewModel:BaseEntity{
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string password { get; set;}
    }

      public class BalanceViewModel : BaseEntity
    {
        [Required]
        [RegularExpression(@"^[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\.[0-9]{2})?$", ErrorMessage = "Not Valid Dollar amount!")]
        public double? amount {get;set;}
    }


}
