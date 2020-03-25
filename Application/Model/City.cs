using System;
using System.Collections.Generic;
using Application.Contracts;

namespace Application.Model
{
    public class City
        : Area, IEntity
    {
        public Guid Id { get; set; }
        public override List<Injury> Injuries { get; set; }
    }
}
