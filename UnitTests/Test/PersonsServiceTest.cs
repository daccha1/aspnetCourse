using ServiceContracts;
using ServiceContracts.DTO;
using System;
using Services;
using System.Security.Cryptography.X509Certificates;
using Entities;

namespace Test
{
	public class PersonsServiceTest
	{
		private readonly IPersonsService _persons;

		public PersonsServiceTest()
		{
			_persons = new PersonsService() { };
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

			


			foreach (PersonResponse p in returnedList)
			{
				Assert.Contains(p, expectedList);
			}

		}


		#endregion
	}
}
