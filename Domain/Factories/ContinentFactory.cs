using Domain.Contract;
using Domain.Model;

namespace Domain.Factories
{
    public class ContinentFactory
        : IContinentFactory
    {
        private readonly ICountriesFactory _countriesFactory;

        public ContinentFactory(ICountriesFactory countriesFactory)
        {
            _countriesFactory = countriesFactory;
        }

        public Continent Create(string continentCode)
        {
            var continent = 
                new Continent
                {
                    Code = continentCode, 
                    Countries = _countriesFactory.Create(continentCode)
                };
            
            switch (continentCode)
            {
                case "EU":
                    continent.Name = "Europa";
                    break;
                case "AM":
                    continent.Name = "America";
                    break;
                default:
                    break;
            }

            return continent;
        }
    }
}
