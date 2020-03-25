using Application.Contracts;
using Application.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WorldService
        : IService<World>
    {

        private readonly Domain.Contract.IService<Domain.Model.World> _domainService;
        private readonly IMapper _mapper;

        public WorldService(Domain.Contract.IService<Domain.Model.World> domainService, IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;
        }
        
        public async Task<List<World>> Get()
        {
            var worlds = await _domainService.Get();
            var result = worlds.Select(x => _mapper.Map<World>(x)).ToList();

            return result;
        }

        public async Task<World> Get(Guid id)
        {
            var world = await _domainService.Get(id);
            var result = _mapper.Map<World>(world);

            return result;
        }

        public async Task Insert(World entity)
        {
            var world = _mapper.Map<Domain.Model.World>(entity);
            await _domainService.Insert(world);
        }

        public async Task Update(Guid id, World entity)
        {
            var world = _mapper.Map<Domain.Model.World>(entity);
            await _domainService.Update(id, world);
        }
    }
}
