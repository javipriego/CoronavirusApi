using Infra.Repository;
using System;

namespace Domain.Model
{
    public class City
        : Area, IEntity
    {
        public Guid Id { get; set; }
    }
}
