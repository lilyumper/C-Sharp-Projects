using System.ComponentModel.DataAnnotations;

namespace Loginreg.Models{
	public class User : BaseEntity{
		[Required]
		[MinLength(4)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string first_name {get; set;}
		
		[Required]
		[MinLength(4)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string last_name {get; set;}


		[Required]
		[EmailAddress]
		public string email{get; set;}


		[Required]
		[MinLength(8)]
		[DataType(DataType.Password)]
		public string password {get; set;}


	



	}
}

	
