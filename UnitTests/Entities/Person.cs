using System;
using System.Collections.Generic;


namespace Entities
{
	public class Person
	{
		public Guid? PersonId { get; set; }
		public string? PersonName { get; set; }
		public string? Email { get; set; }
		public string? Gender { get; set; }
		public DateTime? DOB { get; set; }
		public string? Adress { get; set; }
        public Guid? CountryId { get; set; }
	}
}
