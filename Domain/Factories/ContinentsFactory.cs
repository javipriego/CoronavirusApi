using Domain.Contract;
using Domain.Model;
using System.Collections.Generic;

namespace Domain.Factories
{
    public class ContinentsFactory
        : IContinentsFactory
    {
        private readonly IContinentFactory _continentFactory;
        private List<string> _continentsCodeEA => new List<string> {"EU", "AM", "AS", "AD"};
        
        public ContinentsFactory(IContinentFactory continentFactory)
        {
            _continentFactory = continentFactory;
        }

        public List<Continent> Create(string worldCode)
        {
            
            var continents = new List<Continent>();

            if (Equals(worldCode,"EA"))
            {
                foreach (var continentCode in _continentsCodeEA)
                {
                    var continent = _continentFactory.Create(continentCode);
                    continents.Add(continent);
                }
            }
            
            return continents;
        }
    }
}