using dotidapi.Entity;

namespace dotidapi.Interfaces
{
    public interface IFactRepository
    {
        IEnumerable<PopulationEntity> Get(int region, int sex);
    }
}
