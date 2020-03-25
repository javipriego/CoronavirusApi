using Domain.Model;
using System.Collections.Generic;

namespace Domain.Contract
{
    public interface IWorldsFactory
    {
        List<World> Create();
    }
}
