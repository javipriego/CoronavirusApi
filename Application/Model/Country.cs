using Application.Contracts;
using System;
using System.Collections.Generic;

namespace Application.Model
{
    public class Continent
        : Area, IEntity
    {
        public Guid Id { get; set; }
        public List<Country> Countries { get; set; }
        public override List<Injury> Injuries { get; set; }
    }
}
