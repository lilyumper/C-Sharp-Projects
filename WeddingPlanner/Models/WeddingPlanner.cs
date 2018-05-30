using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models{
	public abstract class BaseEntity {
		public int Id {get; set;}
	}
	public class User : BaseEntity {

		public string fName {get; set;}

		public string lName {get; set;}

		public string Email {get; set;}

		public string Password {get; set;}
	
		public List<Wedding> plans {get; set;}

		public User(){
			plans = new List<Wedding>();
		}
	}

	public class Plan : BaseEntity {

		public string PersonOne {get; set;}

		public string PersonTwo {get; set;}

		public DateTime Date {get; set;}

		public string Address {get; set;}

		public int?  userid {get; set;}

		public User creator {get; set;}

		public List<Wedding> users {get; set;}

		public Plan()
		{
			users = new List<Wedding>();
		}
	}

	public class Wedding : BaseEntity {

		public int? UserId {get; set;}
		public User user {get; set;}

		public int? PlanId {get; set;}
		public Plan plan {get;set;}
	}
/*
	Useful Annotations and Examples:

	[Required] - Makes a field required.
	[RegularExpression(@"[0-9]{0,}\.[0-9]{2}", ErrorMessage = "error Message")] - Put a REGEX string in here.
	[MinLength(100)] - Field must be at least 100 characters long.
	[MaxLength(1000)] - Field must be at most 1000 characters long.
	[Range(5,10)] - Field must be between 5 and 10 characters.
	[EmailAddress] - Field must contain an @ symbol, followed by a word and a period.
	[DataType(DataType.Password)] - Ensures that the field conforms to a specific DataType
*/
}
