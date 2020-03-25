using Application.Contracts;
using Application.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Services;

namespace Application.Services
{
    public class InjuryService
        : IService<Injury>
    {
        private readonly Domain.Contract.IService<Domain.Model.Injury> _service;
        private readonly IMapper _mapper;

        public InjuryService(Domain.Contract.IService<Domain.Model.Injury> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<Injury>> Get()
        {
            var injuries = await _service.Get();
            var result = _mapper.Map<List<Injury>>(injuries);
            return result;
        }

        public async Task<Injury> Get(Guid id)
        {
            var injury = await _service.Get(id);
            var result = _mapper.Map<Injury>(injury);
            return result;
        }

        public async Task Insert(Injury entity)
        {
            var injury = _mapper.Map<Domain.Model.Injury>(entity);
            await _service.Insert(injury);
        }

        public async Task Update(Guid id, Injury entity)
        {
            var injury = _mapper.Map<Domain.Model.Injury>(entity);
            await _service.Update(id, injury);
        }
    }
}
