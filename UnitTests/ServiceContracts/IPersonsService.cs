using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
	public interface IPersonsService
	{
		public PersonResponse AddPerson(PersonAddRequest personAddRequest);
		public List<PersonResponse> GetAllPersons();
	}
}
