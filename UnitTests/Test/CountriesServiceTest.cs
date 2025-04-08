using System;
using System.Collections.Generic;
using ServiceContracts;
using Entities;
using Services;
using ServiceContracts.DTO;
using System.Security.Cryptography.X509Certificates;

namespace Test
{
	public class CountriesServiceTest
	{
		private readonly ICountriesService _countriesService;
		
		public CountriesServiceTest()
		{
			_countriesService = new CountriesService() { };
		}

		#region AddCountry

		[Fact]
		public void AddCountry_NullCountry()
		{
			// Arrange

			CountryAddRequest? request = null;

			// Assert
			Assert.Throws<ArgumentNullException>( () => // metoda koja proverava da li funkcija unutar lamba izraza baca NULL VREDNOST
			{
				// Act
				_countriesService.AddCountry(request);  // ==> ako je NULL, test ce PROCI, ako nije => TEST PADA
			});

		}

		[Fact]
		public void AddCountry_ObjectNameNull()
		{
			// Arrange
			CountryAddRequest request = new CountryAddRequest() { CountryName = null };


			// Assert
			Assert.Throws<ArgumentException>(() => {
				// Act
				_countriesService.AddCountry(request);
			});

		}

		[Fact]
		public void AddCountry_DuplicateName()
		{
			// Arrange
			CountryAddRequest request1 = new CountryAddRequest() { CountryName = "Serbia" };
			CountryAddRequest request2 = new CountryAddRequest() { CountryName = "Serbia" };


			// Assert
			Assert.Throws<ArgumentException>(() => {
				// Act
				_countriesService.AddCountry(request1);
				_countriesService.AddCountry(request2);
			});

		}


		[Fact]
		public void AddCountry_ProperCountryDetails()
		{
			// REQUEST za dodavanje
			CountryAddRequest request = new CountryAddRequest() { CountryName = "Serbia" };

			// ACT : generisanje Response zahteva

			CountryResponse response = _countriesService.AddCountry(request);

			// Assert
			Assert.True(response.CountryId != Guid.Empty);

		}

		#endregion

		#region GetAllCountries
		[Fact]
		public void GetAllCountries_EmptyList()
		{
			
			// Act
			List<CountryResponse> response = _countriesService.GetAllCountries();

			// Assert
			Assert.Empty(response);

		}

		[Fact]
		public void GetAllCountries_ReturnsValidList()
		{

			// Arrange 
			List<CountryAddRequest> countries_add_request = new List<CountryAddRequest>
			{
				new CountryAddRequest() {CountryName = "Serbia"},
				new CountryAddRequest() {CountryName = "USA"},
				new CountryAddRequest() {CountryName = "Bosnia"},
			};

			List<CountryResponse> countries_from_addCountry_method = new List<CountryResponse>();

			// Act
			foreach(CountryAddRequest c in countries_add_request)
			{
				countries_from_addCountry_method.Add(_countriesService.AddCountry(c));
			}

			List<CountryResponse> actual_countries_from_GetAll = _countriesService.GetAllCountries();

			// Assert
			foreach(CountryResponse expected_country in actual_countries_from_GetAll)
			{
				Assert.Contains(expected_country, countries_from_addCountry_method);
			}
		}
		#endregion

		#region GetCountryById

		// GUID id == null
		// Country != postoji
		// Prazna lista

		//GetCountryById

		[Fact]
		public void GetCountryById_Id_Valid_Return()
		{
			CountryAddRequest countryAddRequest = new CountryAddRequest()
			{
				CountryName = "Serbia"
			};

			CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

			// Act

			CountryResponse expected_country = new CountryResponse();
			expected_country = _countriesService.GetCountryById(countryResponse.CountryId);

			// Assert
			Assert.Equal(countryResponse.CountryId, expected_country.CountryId);

		}

		[Fact]
		public void GetCountryById_Non_Existant_Id()
		{
			
			Guid testGuid = Guid.NewGuid();
			CountryResponse? actual = new CountryResponse() { CountryId = testGuid, CountryName="Serbia" };

			Assert.Throws<KeyNotFoundException>(() =>
			{
				_countriesService.GetCountryById(actual.CountryId);
			});

		}



		#endregion

	}
}
