using Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Model
{
    public class World
        : Area, IEntity
    {
        public Guid Id { get; set; }
        public List<Continent> Continents { get; set; }

        public override int InitialAffected {
            get { return Continents?.Sum(x => x.InitialAffected) ?? 0; }
        }

        public override int InitialDeath
        {
            get { return Continents?.Sum(x => x.InitialDeath) ?? 0; }
        }

        public override int InitialRecovered
        {
            get { return Continents?.Sum(x => x.InitialRecovered) ?? 0; }
        }

        public override List<Injury> Injuries
        {
            get { return Continents?.SelectMany(x => x.Injuries).ToList() ?? new List<Injury>(); }
            set { }
        }
    }
}
