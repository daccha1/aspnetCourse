using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ServiceContracts.DTO
{
	public class PersonResponse
	{
		public Guid? PersonId { get; set; }
		public string? PersonName { get; set; }
		public string? Email { get; set; }
		public string? Gender { get; set; }
		public DateTime? DOB { get; set; }
		public string? Adress { get; set; }
		public Guid? CountryId { get; set; }
	}

	public static class PersonExtension
	{
		public static PersonResponse ToPersonResponse(this Person p)
		{
			return new PersonResponse
			{
				PersonId = p.PersonId,
				PersonName = p.PersonName,
				Email = p.Email,
				Gender = p.Gender,
				Adress = p.Adress,
				DOB = p.DOB,
				CountryId = p.CountryId,
			};
		}
	}

}
