using Azure.Core;
using dotidapi.Context;
using dotidapi.Entity;
using dotidapi.Interfaces;

namespace dotidapi.DataAccess
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DotIdContext _context;

        public RegionRepository(DotIdContext context) {  _context = context; }

        public RegionEntity? Get(int Id)
        {
            return _context.Regions.Where(region => region.Id == Id).FirstOrDefault();
        }

    }
}
