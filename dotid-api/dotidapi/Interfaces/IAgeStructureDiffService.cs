using System.Xml.Serialization;
using dotidapi.Models;

namespace dotidapi.Interfaces
{
    public interface IAgeStructureDiffService
    {
        Task<AgeStructureDiffResponse> GetAgeStructureDiff(AgeStructureDiffRequest request);
    }
}
