using Domain.Model;
using System.Collections.Generic;

namespace Domain.Contract
{
    public interface IContinentsFactory
    {
        List<Continent> Create(string worldCode);
    }
}
