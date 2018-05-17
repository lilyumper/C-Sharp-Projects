using System;

namespace Banker.Models{
	public abstract class BaseEntity{

		public int Id {get; set;}

		public DateTime created_at = DateTime.Now;
		public DateTime updated_at = DateTime.Now;
	}
}
