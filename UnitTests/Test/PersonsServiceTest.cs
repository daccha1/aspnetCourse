using ServiceContracts;
using ServiceContracts.DTO;
using System;
using Services;
using System.Security.Cryptography.X509Certificates;
using Entities;
using Xunit.Sdk;

namespace Test
{
	public class PersonsServiceTest
	{
		private readonly IPersonsService _persons;
		private readonly ICountriesService _countries;

		public PersonsServiceTest()
		{
			_persons = new PersonsService() { };
			_countries = new CountriesService() { };
		}
		#region AddPerson
		[Fact]
		public void AddPerson_Request_is_null()
		{
			PersonAddRequest? request = null;

			// Assert
			Assert.Throws<ArgumentNullException>(() =>
			{
				_persons.AddPerson(request);
			});
		}

		[Fact]
		public void AddPerson_PersonName_Null()
		{
			PersonAddRequest request = new PersonAddRequest { PersonName = null};

			// Assert
			Assert.Throws<ArgumentException>(() =>
			{
				_persons.AddPerson(request);
			});
		}

		[Fact]
		public void AddPerson_Person_Exists()
		{
			PersonAddRequest addReq1 = new PersonAddRequest { PersonName = "David" };
			PersonAddRequest addReq2 = new PersonAddRequest { PersonName = "David" };

			
			// Assert
			Assert.Throws<ArgumentException>(() =>
			{
				// Act
				PersonResponse response1 = _persons.AddPerson(addReq1);
				PersonResponse response2 = _persons.AddPerson(addReq2);
			});

		}
		#endregion

		#region GetAllPersons

	
		public void GetAllPersons_EmptyList()
		{
			List<PersonResponse> persons = _persons.GetAllPersons();

			Assert.Empty(persons);
		}

		[Fact]
		public void GetAllPersons_ReturnsValidList()
		{
			List<Person> persons = new List<Person>()
			{
				new Person {PersonName="David"},
				new Person {PersonName="Danijel"},
				new Person {PersonName="Darko"},
			};

			List<PersonResponse> expectedList = new List<PersonResponse>();

			foreach(Person p in persons)
			{
				expectedList.Add(p.ToPersonResponse());
				
			}


			List<PersonResponse> returnedList = _persons.GetAllPersons();

			foreach (PersonResponse p in returnedList)
			{
				Assert.Contains(p, expectedList);
			}

		}


		#endregion

		#region GetPersonById

		[Fact]
		public void GetPersonById_CorrectPerson()
		{
			// arrange
			PersonAddRequest person = new PersonAddRequest
			{
				PersonName = "David",
				Email = "person@gmail.com"
			};

			PersonResponse? expected = _persons.AddPerson(person);

			// act
			PersonResponse? response = _persons.GetPersonById(expected.PersonId);

			// assert
			Assert.Equal(expected.PersonId, response.PersonId);
		}

		[Fact]
		public void GetPersonById_ReturnsNullWhenNotFound()
		{
			Guid id = Guid.NewGuid();

			//Person p = new Person { PersonId = Guid.NewGuid(), PersonName = "Person" };

			//List<Person> personList = new List<Person>();
			//personList.Add(p);

			// act
			PersonResponse response = _persons.GetPersonById(id);

			// assert
			Assert.Throws<NullException>( () =>
			{
                PersonResponse response = _persons.GetPersonById(id);
            });


		}

		#endregion

		#region UpdatePerson

		[Fact]
		public void UpdatePerson_NullIfNotFound()
		{
			PersonUpdateRequest updateRequest = new PersonUpdateRequest
			{
				PersonId = Guid.NewGuid(),
				PersonName = "Person",
				Adress = "Person addy",
				CountryId = Guid.NewGuid(),
				DOB = DateTime.Now,
				Email = "person@gmail.com",
				Gender = "Male"
			};

			PersonResponse response = _persons.UpdatePerson(updateRequest);

			Assert.Null(response);
		}

		[Fact]
		public void UpdatePerson_ValidUpdateDone()
		{
			CountryAddRequest country_add_req = new CountryAddRequest
			{
				CountryName = "Serbia"
			};

			CountryResponse country_response = _countries.AddCountry(country_add_req);

			PersonAddRequest person_add = new PersonAddRequest
			{
				PersonName = "Person",
				Adress = "Address",
				CountryId = country_response.CountryId,
				DOB = DateTime.Now,
				Email = "person@person.com",
				Gender = "M"
			};

			PersonResponse personResponse = _persons.AddPerson(person_add);
			PersonUpdateRequest personUpdate = personResponse.ToPersonUpdate();
			personUpdate.Email = "person2@gmail.com";
			personUpdate.PersonName = "Peter";

			PersonResponse personResponseFromUpdate = _persons.UpdatePerson(personUpdate);
			PersonResponse personResponseFromGetId = _persons.GetPersonById(personResponse.PersonId);

			// Assert
			Assert.Equal(personResponseFromGetId.PersonName, personResponseFromUpdate.PersonName);


		}

        #endregion

        #region DeletePerson
        
		[Fact]
        public void DeletePerson_NotFoundPerson()
		{	
			bool deletedPerson = _persons.DeletePerson(Guid.NewGuid());
			Assert.False(deletedPerson);
		}

		#endregion
	}
}
