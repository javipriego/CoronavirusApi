using System;
using System.Collections.Generic;
using Domain.Contract;
using Domain.Enums;
using Domain.Model;

namespace Domain.Factories
{
    public class CountryFactory
        : ICountryFactory
    {
        public Country Create(string countryCode)
        {
            if (countryCode == "SP")
            {
                return createSpain();
            }

            var country = 
                new Country
                {
                    Code = countryCode
                };

            return country;
        }

        private Country createSpain()
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

            return country;
        }
    }
}