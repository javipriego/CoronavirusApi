using Domain.Model;

namespace Domain.Contract
{
    public interface IContinentFactory
    {
        Continent Create(string continentCode);
    }
}