using dotidapi.Entity;

namespace dotidapi.Models
{
    public record AgeStructureResponse
    {
        public string RegionCode { get; set; } = string.Empty;

        public string RegionName { get; set; } = string.Empty;

        public IEnumerable<PopulationEntity>? Data { get; set; }

    }

    public record AgeStructureResponseData
    {
        public string Age { get; set; } = string.Empty;

        public string Sex { get; set; } = string.Empty;

        public int Population { get; set; }
    }

    public record AgeStructureResponseDiffData : AgeStructureResponseData
    {
        public int CensusYear { get; set; }
    }

    public record AgeStructureDiffResponse
    {
        public string RegionCode { get; set; } = string.Empty;

        public string RegionName { get; set; } = string.Empty;

        public string CensusYear { get; set;} = string.Empty;

        public IEnumerable<AgeDifferenceModel>? Data { get; set; }
    }
}