using dotidapi.Context;
using dotidapi.Interfaces;
using dotidapi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace dotidapi.Services
{
    public class AgeStructureDiffService : IAgeStructureDiffService
    {
        private readonly IAgeStructureDataAccess _ageStructureDataAccess;
        private readonly IRegionRepository _regionRepository;

        public AgeStructureDiffService(
            IRegionRepository regionRepository, 
            IAgeStructureDataAccess ageStructureDataAccess) { 
        
            _regionRepository = regionRepository;
            _ageStructureDataAccess = ageStructureDataAccess;
        }

        public async Task<AgeStructureDiffResponse> GetAgeStructureDiff(AgeStructureDiffRequest request)
        {
            var region = _regionRepository.Get(request.Code);

            var difference = await _ageStructureDataAccess.GetAgeDifferenceModelAsync(request);

            return new AgeStructureDiffResponse
            {
                RegionCode = region.Id.ToString(),
                RegionName = region.Name,
                CensusYear = $"{request.Year1} - {request.Year2}",
                Data = difference,
            };
        }
    }
}
