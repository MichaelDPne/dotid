using dotidapi.Context;
using dotidapi.Interfaces;
using dotidapi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace dotidapi.Services
{
    public class AgeStructureService : IAgeStructureService
    {
        private readonly IAgeStructureDataAccess _ageStructureDataAccess;
        private readonly IRegionRepository _regionRepository;
        private readonly IFactRepository _factRepository;


        public AgeStructureService(
            IRegionRepository regionRepository, 
            IFactRepository factRepository) { 
        
            _regionRepository = regionRepository;
            _factRepository = factRepository;
        }

        public async Task<AgeStructureResponse> GetAgeStructure(AgeStructureRequest request)
        {

            var region = _regionRepository.Get(request.Code);
            var data = _factRepository.Get(request.Code, request.Sex);


            return new AgeStructureResponse
            {
                RegionCode = region.Id.ToString(),
                RegionName = region.Name,
                Data = data,
            };
        }
    }
}
