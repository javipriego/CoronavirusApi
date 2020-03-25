using Application.Contracts;
using Application.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CountryService
        : IService<Country>
    {

        private readonly Domain.Contract.IService<Domain.Model.Country> _domainService;
        private readonly IMapper _mapper;

        public CountryService(Domain.Contract.IService<Domain.Model.Country> domainService, IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;
        }
        
        public async Task<List<Country>> Get()
        {
            var countries = await _domainService.Get();
            var result = countries.Select(x => _mapper.Map<Country>(x)).ToList();

            return result;
        }

        public async Task<Country> Get(Guid id)
        {
            var country = await _domainService.Get(id);
            var result = _mapper.Map<Country>(country);

            return result;
        }

        public async Task Insert(Country entity)
        {
            var country = _mapper.Map<Domain.Model.Country>(entity);
            await _domainService.Insert(country);
        }

        public async Task Update(Guid id, Country entity)
        {
            var country = _mapper.Map<Domain.Model.Country>(entity);
            await _domainService.Update(id, country);
        }
    }
}
