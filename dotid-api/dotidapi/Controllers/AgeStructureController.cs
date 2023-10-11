using dotidapi.Interfaces;
using dotidapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotidapi.Controllers
{
    public class AgeStructureController : Controller
    {
        private readonly IAgeStructureService _ageStructureService;
        private readonly IAgeStructureDiffService _ageStructureDiffService;

        public AgeStructureController(
            IAgeStructureService ageStructureService,
            IAgeStructureDiffService ageStructureDiffService)
        {
            this._ageStructureService = ageStructureService;
            this._ageStructureDiffService = ageStructureDiffService;
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
            return await this._ageStructureDiffService.GetAgeStructureDiff(request);
        }
    }
}