using System;
using System.ComponentModel.DataAnnotations;

namespace Restauranter.Models
{
      public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if(dt <= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
    public class RegisterViewModel : BaseEntity{
        [Required]
        [MinLength(4)]
        public string Name{get; set;}

        [Required]
        [MinLength(2)]
        public string Resturant {get; set;}

        [Required]
        [MinLength(10)]
        public string Review {get; set;}

        [Required]
        [Range(1,5)]

        public int Stars {get; set;}

        [Required]
        [CurrentDate]
        [DataType(DataType.DateTime)]
        public DateTime Attended{get; set;}



    } 
}