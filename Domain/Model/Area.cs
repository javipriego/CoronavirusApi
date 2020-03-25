using System.Collections.Generic;
using System.Linq;
using Domain.Enums;

namespace Domain.Model
{
    public abstract class Area
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int InitialCases => InitialAffected + InitialDeath + InitialRecovered ;
        public virtual int InitialAffected { get; set; } = 0;
        public virtual int InitialDeath { get; set; } = 0;
        public virtual int InitialRecovered { get; set; } = 0;
        public int Cases => Affected + Death + Recovered;
        public int Affected => InitialAffected + (Injuries?.Count(x => x.Type == InjuryType.Infected) ?? 0);
        public int Death => InitialDeath + (Injuries?.Count(x => x.Type == InjuryType.Death) ?? 0);
        public int Recovered => InitialRecovered + (Injuries?.Count(x => x.Type == InjuryType.Recovered) ?? 0);
        public virtual List<Injury> Injuries { get; set; }
    }
}