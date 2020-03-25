using Application.Contracts;
using System;
using System.Collections.Generic;

namespace Application.Model
{
    public class World
        : Area, IEntity
    {
        public Guid Id { get; set; }
        public List<Continent> Continents { get; set; }
        public override List<Injury> Injuries { get; set; }
    }
}
