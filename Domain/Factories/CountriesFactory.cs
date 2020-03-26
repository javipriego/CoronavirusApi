using System;
using System.Collections.Generic;
using Domain.Contract;
using Domain.Enums;
using Domain.Model;

namespace Domain.Factories
{
    public class CountriesFactory
        : ICountriesFactory
    {
        private ICountryFactory _countryFactory;

        public CountriesFactory(ICountryFactory countryFactory)
        {
            _countryFactory = countryFactory;
        }

        public List<Country> CreateSpain()
        {
            var injuries = new List<Injury>();
            var injury =
                new Injury
                {
                    Id = Guid.NewGuid(),
                    Type = InjuryType.Infected,
                    DateTime = DateTime.Today
                };

            injuries.Add(injury);

            var countries = new List<Country>();
            var cities = new List<City>();

            var city =
                new City
                {
                    Id = Guid.NewGuid(),
                    Code = "CO",
                    Name = "Cordoba",
                    Injuries = injuries,
                    InitialAffected = 10,
                    InitialDeath = 0,
                    InitialRecovered = 3
                };

            cities.Add(city);

            var country =
                new Country
                {
                    Id = Guid.NewGuid(),
                    Code = "ESP",
                    Name = "España",
                    Cities = cities
                };

            countries.Add(country);

            return countries;
        }

        public List<Country> Create(string continentCode)
        {
            var countries = new List<Country>();
            switch (continentCode)
            {
                case "EU":
                    countries.Add(_countryFactory.Create("SP"));
                    countries.Add(_countryFactory.Create("FR"));
                    countries.Add(_countryFactory.Create("IT"));
                    countries.Add(_countryFactory.Create("PO"));
                    break;
            }

            return countries;
        }
    }
}