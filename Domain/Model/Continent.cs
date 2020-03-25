using Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Model
{
    public class Continent
        : Area, IEntity
    {
        public Guid Id { get; set; }
        public List<Country> Countries { get; set; }

        public override int InitialAffected {
            get { return Countries?.Sum(x => x.InitialAffected) ?? 0 ; }
        }

        public override int InitialDeath
        {
            get { return Countries?.Sum(x => x.InitialDeath) ?? 0 ; }
        }

        public override int InitialRecovered
        {
            get { return Countries?.Sum(x => x.InitialRecovered) ?? 0; }
        }

        public override List<Injury> Injuries
        {
            get { return Countries?.SelectMany(x => x?.Injuries).ToList() ?? new List<Injury>(); }
            set { }
        }
    }
}
