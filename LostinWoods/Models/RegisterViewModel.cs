using System.ComponentModel.DataAnnotations;

namespace LostinWoods.Models
{
    public class RegisterViewModel : BaseEntity{
        [Required]
        [MinLength(4)]
        public string name{get; set;}

        [Required]
        [MinLength(10)]
        public string description {get; set;}

        [Required]
        [Range(0,15000)]
        public int traillength {get; set;}

        [Required]
        [Range(0,int.MaxValue)]
        public int elevation {get; set;}

        [Required]
        [Range(-180,180)]

        public float log {get; set;}

        [Required]
        [Range(-90,90)]

        public float lat{get; set;}



    } 
}