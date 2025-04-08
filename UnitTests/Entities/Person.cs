using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
	public class Person
	{

		
		public Guid? PersonId { get; set; }
        [Required(ErrorMessage = "Person name is a mandatory input.")]
        public string? PersonName { get; set; }
		[EmailAddress(ErrorMessage = "Email is mandatory input.")]
		public string? Email { get; set; }
		public string? Gender { get; set; }
		public DateTime? DOB { get; set; }
		public string? Adress { get; set; }
        public Guid? CountryId { get; set; }
	}
}
