using System;

namespace Application.Contracts
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}