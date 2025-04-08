using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
namespace Services
{
	public class PersonsService : IPersonsService
	{
		private readonly List<Person> persons;

		public PersonsService()
		{
			persons = new List<Person>();
		}

		public PersonResponse AddPerson(PersonAddRequest personAddRequest)
		{
			if(personAddRequest == null)
			{
				throw new ArgumentNullException();
			}

			if(personAddRequest.PersonName == null)
			{
				throw new ArgumentException();
			}

			Person? p = persons.FirstOrDefault(person => person.PersonName == personAddRequest.PersonName);			

			if(p == null)
			{
				throw new ArgumentException();
			}

			p = personAddRequest.ToPerson();
			p.PersonId = Guid.NewGuid();
			persons.Add(p);
			return p.ToPersonResponse();
		}

		public List<PersonResponse> GetAllPersons()
		{
			if(persons == null)
			{
				throw new ArgumentException();
			}

			if(persons.Count == 0)
			{
				throw new ArgumentException();
			}

			List<PersonResponse> returnList = new List<PersonResponse>();

			foreach(Person p in persons)
			{
				returnList.Add(p.ToPersonResponse());
			}

			return returnList;
		}


	}
}
