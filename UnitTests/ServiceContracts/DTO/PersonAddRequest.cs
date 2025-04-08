using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace ServiceContracts.DTO
{
	public class PersonAddRequest
	{
		public string? PersonName { get; set; }
		public string? Email { get; set; }
		public string? Gender { get; set; }
		public DateTime? DOB { get; set; }
		public string? Adress { get; set; }
		public Guid? CountryId { get; set; }
		
		public Person ToPerson()
		{
			Person person = new Person()
			{
				PersonName = PersonName,
				Email = Email,
				Gender = Gender,
				CountryId = CountryId,
				DOB = DOB,
				Adress = Adress
			};

			return person;
		}
	}
}
