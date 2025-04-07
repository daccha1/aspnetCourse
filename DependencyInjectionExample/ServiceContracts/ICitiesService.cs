using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
	public interface ICitiesService
	{
		// upisujemo samo metodu/e koje planiramo da implementiramo u servisima
		List<string> GetCities();
	}
}
