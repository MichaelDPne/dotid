using dotidapi.Context;
using dotidapi.Interfaces;
using dotidapi.Models;

namespace dotidapi.Services
{
    public class AgeStructureService : IAgeStructureService
    {
        private readonly DotIdContext _context;
        
        public AgeStructureService(DotIdContext context) { 
        
            _context = context;
        }


        public async Task<AgeStructureResponse> GetAgeStructure(AgeStructureRequest request)
        {
            var data = _context.FactPopulations.Where(population => population.Region == request.Code && population.Sex == request.Sex);

            var region = _context.Regions.Where(region => region.Id == request.Code).FirstOrDefault();

            return new AgeStructureResponse
            {
                RegionCode = region.Id.ToString(),
                RegionName = region.Name,
                Data = data,
            };
        }

        public async Task<AgeStructureDiffResponse> GetAgeStructureDiff(AgeStructureDiffRequest request)
        {
            var data = _context.FactPopulations.Where(population => population.Region == request.Code && population.Sex == request.Sex);

            var region = _context.Regions.Where(region => region.Id == request.Code).FirstOrDefault();

            return new AgeStructureDiffResponse
            {
                RegionCode = region.Id.ToString(),
                RegionName = region.Name,
                Data = null,
            };
        }
    }
}
