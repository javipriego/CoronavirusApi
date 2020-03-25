using Domain.Model;
using System.Collections.Generic;

namespace Domain.Contract
{
    public interface ICountriesFactory
    {
        List<Country> Create(string continentCode);
    }
}
