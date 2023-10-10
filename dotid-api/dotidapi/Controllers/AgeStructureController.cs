using dotidapi.Interfaces;
using dotidapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotidapi.Controllers
{
    public class AgeStructureController : Controller
    {
        private readonly IAgeStructureService _ageStructureService;

        public AgeStructureController(IAgeStructureService ageStructureService) { 
            this._ageStructureService = ageStructureService;
        }

        [Route("age-structure/{code}/{sex}")]
        [HttpGet]
        public async Task<AgeStructureResponse> GetAgeStructure(AgeStructureRequest request)
        {
            return await this._ageStructureService.GetAgeStructure(request);
        }

        [Route("age-structure-diff/{code}/{sex}/{year1}/{year2}")]
        [HttpGet]
        public async Task<AgeStructureDiffResponse> GetAgeStructureDiff(AgeStructureDiffRequest request)
        {
            return await this._ageStructureService.GetAgeStructureDiff(request);
        }
    }
}