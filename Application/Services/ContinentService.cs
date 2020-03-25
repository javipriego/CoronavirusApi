using Application.Contracts;
using Application.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContinentService
        : IService<Continent>
    {

        private readonly Domain.Contract.IService<Domain.Model.Continent> _domainService;
        private readonly IMapper _mapper;

        public ContinentService(Domain.Contract.IService<Domain.Model.Continent> domainService, IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;
        }
        
        public async Task<List<Continent>> Get()
        {
            var continents = await _domainService.Get();
            var result = continents.Select(x => _mapper.Map<Continent>(x)).ToList();

            return result;
        }

        public async Task<Continent> Get(Guid id)
        {
            var continent = await _domainService.Get(id);
            var result = _mapper.Map<Continent>(continent);

            return result;
        }

        public async Task Insert(Continent entity)
        {
            var continent = _mapper.Map<Domain.Model.Continent>(entity);
            await _domainService.Insert(continent);
        }

        public async Task Update(Guid id, Continent entity)
        {
            var continent = _mapper.Map<Domain.Model.Continent>(entity);
            await _domainService.Update(id, continent);
        }
    }
}
