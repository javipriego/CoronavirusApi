using System.Collections.Generic;

namespace Application.Model
{
    public abstract class Area
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int InitialCases { get; set; }
        public int InitialAffected { get; set; }
        public int InitialDeath { get; set; }
        public int InitialRecovered { get; set; }
        public int Cases { get; set; }
        public int Affected { get; set; }
        public int Death { get; set; }
        public int Recovered { get; set; }
        public abstract List<Injury> Injuries { get; set; }
    }
}