using dotidapi.Models;

namespace dotidapi.Interfaces
{
    public interface IAgeStructureDataAccess
    {
        Task<IEnumerable<AgeDifferenceModel>> GetAgeDifferenceModelAsync(AgeStructureDiffRequest request);
    }
}
