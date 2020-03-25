using Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Model
{
    public class Country
        : Area, IEntity
    {
        public Guid Id { get; set; }
        public List<City> Cities { get; set; }

        public override int InitialAffected {
            get { return Cities?.Sum(x => x.InitialAffected) ?? 0 ; }
        }

        public override int InitialDeath
        {
            get { return Cities?.Sum(x => x.InitialDeath) ?? 0; }
        }

        public override int InitialRecovered
        {
            get { return Cities?.Sum(x => x.InitialRecovered) ?? 0; }
        }

        public override List<Injury> Injuries
        {
            get { return Cities?.SelectMany(x => x.Injuries).ToList() ?? new List<Injury>(); }
            set { }
        }
    }
}
