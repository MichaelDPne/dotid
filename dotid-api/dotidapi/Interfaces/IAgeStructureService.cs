using System.Xml.Serialization;
using dotidapi.Models;

namespace dotidapi.Interfaces
{
    public interface IAgeStructureService
    {
        Task<AgeStructureResponse> GetAgeStructure(AgeStructureRequest request);
       
    }
}
