using Domain.Model;

namespace Domain.Contract
{
    public interface ICountryFactory
    {
        Country Create(string countryCode);
    }
}
