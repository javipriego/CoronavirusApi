using System;
using Domain.Contract;
using Domain.Model;
using System.Collections.Generic;

namespace Domain.Factories
{
    public class WorldsFactory
        : IWorldsFactory
    {
        private IContinentsFactory _continentsFactory;

        public WorldsFactory(IContinentsFactory continentsFactory)
        {
            _continentsFactory = continentsFactory;
        }

        public List<World> Create()
        {
            var continents = _continentsFactory.Create("EA");

            var world = new World {Code = "EA", Name = "Earth", Id = Guid.NewGuid(), Continents = continents};

            var worlds = new List<World> {world};
            
            return worlds;
        }
    }
}