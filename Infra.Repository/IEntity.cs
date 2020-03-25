using System;

namespace Infra.Repository
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}