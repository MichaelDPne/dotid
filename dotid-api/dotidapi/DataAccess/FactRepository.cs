using Azure.Core;
using dotidapi.Context;
using dotidapi.Entity;
using dotidapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotidapi.DataAccess
{
    public class FactRepository : IFactRepository
    {
        private readonly DotIdContext _context;

        public FactRepository(DotIdContext context) { _context = context; }

        public IEnumerable<PopulationEntity> Get(int region, int sex)
        {
            return _context.FactPopulations.Where(population => population.Region == region && population.Sex == sex);
        }
    }
}
