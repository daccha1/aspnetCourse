using System;
using System.Collections.Generic;
using Entities;

namespace ServiceContracts.DTO
{
	// mora biti public

	/// <summary>
	/// DTO class that is used as return type for most 
	/// of CountriesService methods
	/// </summary>
	public class CountryResponse
	{
		public Guid? CountryId { get; set; }
		public string? CountryName { get; set; }
		 
	}

	public static class CountryExtension
	{
		public static CountryResponse ToCountryResponse(this Country country) // this Country => naglasava da se vrsi ekstenzije klase Country
		{
			return new CountryResponse { CountryId = country.Id, CountryName = country.Name };
		}
	}
}
