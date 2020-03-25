using Application.Enums;
using System;
using Application.Contracts;

namespace Application.Model
{
    public class Injury
        : IEntity
    {
        public Guid Id { get; set; }

        public string CityCode { get; set; }

        public string CountryCode { get; set; }

        public DateTime DateTime { get; set; }

        public InjuryType Type { get; set; }
    }
}
