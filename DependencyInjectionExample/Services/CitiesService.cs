using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService
    {
        private List<string> _cities;

        public CitiesService() 
        {
         _cities = new List<string>();
            _cities.Add("London");
            _cities.Add("Paris");
            _cities.Add("Tokyo");
            _cities.Add("New York");
            _cities.Add("Rome");
        }

        public List<string> GetCities()
        {
            return _cities;
        }

    }
}
