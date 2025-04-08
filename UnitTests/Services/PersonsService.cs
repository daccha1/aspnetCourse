using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Services.Helpers;
using System.Net.Http.Headers;
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

			ModelValidations.ModelValidation(personAddRequest);
			

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

		public PersonResponse GetPersonById(Guid? id)
		{
			if(id == null)
			{
				throw new ArgumentNullException();
			}

			Person p = persons.FirstOrDefault(person => person.PersonId == id);
			
			if(p == null)
			{
				throw new ArgumentNullException();
			}

			return p.ToPersonResponse();

		}

        public List<PersonResponse>? GetFilteredPersons(string searchBy, string? searchString)
		{
			throw new NotImplementedException();
		}

        public PersonResponse? UpdatePerson(PersonUpdateRequest personUpdateRequest)
		{
			if(personUpdateRequest == null)
			{
				throw new ArgumentNullException();
			}

			ModelValidations.ModelValidation(personUpdateRequest);

			if(personUpdateRequest.PersonId == null)
			{
				throw new ArgumentException();
			}

			Person? p = persons.FirstOrDefault(p => p.PersonId == personUpdateRequest.PersonId);

			if(p == null)
			{
				throw new ArgumentException();
			}
			
			PersonResponse response = p.ToPersonResponse();
            response.PersonName = personUpdateRequest.PersonName;
            response.Gender = personUpdateRequest.Gender;
            response.Adress = personUpdateRequest.Adress;
            response.DOB = personUpdateRequest.DOB;
            response.Email = personUpdateRequest.Email;

			return response;

		}

		public bool DeletePerson(Guid? PersonId)
		{
			if(PersonId == null)
			{
				throw new ArgumentNullException();
			}

			Person? p = persons.FirstOrDefault(person => person.PersonId == PersonId);

			if(p == null)
			{
				return false;
			}

			persons.Remove(p);
			return true;
		}
    }
}
