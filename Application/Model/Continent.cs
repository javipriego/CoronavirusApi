using Application.Contracts;
using System;
using System.Collections.Generic;

namespace Application.Model
{
    public class Country
        : Area, IEntity
    {
        public Guid Id { get; set; }
        public List<City> Cities { get; set; }
        public override List<Injury> Injuries { get; set; }
    }
}
