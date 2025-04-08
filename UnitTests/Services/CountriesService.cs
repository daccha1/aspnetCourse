using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services
{
	public class CountriesService : ICountriesService
	{
		private readonly List<Country> _countries;

		public CountriesService()
		{
			_countries = new List<Country>();
		}

		public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
		{
			// validacije:
			
			// da li je objekat NULL
			// da li string razlicit od null
			// duplikat

			if(countryAddRequest == null)
			{
				throw new ArgumentNullException();
			}

			if (countryAddRequest.CountryName == null)
			{
				throw new ArgumentException();
			}

			foreach (Country cn in _countries)
			{
				if (countryAddRequest.CountryName == cn.Name)
				{
					throw new ArgumentException("Country already exists");
				}
			}

			Country c = countryAddRequest.ToCountry();

			c.Id = Guid.NewGuid();
			_countries.Add(c);
			return c.ToCountryResponse();
		}

		public List<CountryResponse> GetAllCountries()
		{
			// validacije:
			// da li je prazna lista
			// da li je lista = null (nije inicijalizovana)

			if(_countries == null)
			{
				throw new NullReferenceException();
			}


			List<CountryResponse> countriesList = new List<CountryResponse>();

			foreach(Country c in _countries)
			{
				countriesList.Add(c.ToCountryResponse());
			}

			return new List<CountryResponse>();

			// Pravimo TEMP listu tipa CountryResponse
			// Prolazi kroz listu _countries i svaku konvertuje + dodaje u temp listu
			// na kraju vraca temp listu
		}

		public CountryResponse GetCountryById(Guid? id)
		{
			if(id == null)
			{
				return null;
			}

			Country? expected = new Country(); // storing the lookup object
			expected = _countries.FirstOrDefault(c => c.Id == id);

			if(expected == null)
			{
				throw new KeyNotFoundException();
			}

			CountryResponse? expectedResponse = expected.ToCountryResponse();
			return expectedResponse;

		}
	}
}
