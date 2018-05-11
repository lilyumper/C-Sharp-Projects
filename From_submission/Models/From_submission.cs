using System.ComponentModel.DataAnnotations;

namespace From_submission.Models{
	


	public class User :BaseEntity
	{
		[Required]
		[MinLength(4)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string fname {get; set;}
		
		[Required]
		[MinLength(4)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string lname {get; set;}

		[Required]
		[RegularExpression("^[0-9]+$", ErrorMessage ="Only positive numbers allowed")] 
		public int age {get; set;}

		[Required]
		[EmailAddress]
		public string email{get; set;}


		[Required]
		[MinLength(8)]
		[DataType(DataType.Password)]
		public string password {get; set;}


	



	}
}

