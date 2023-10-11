using dotidapi.Entity;

namespace dotidapi.Interfaces
{
    public interface IRegionRepository
    {
        RegionEntity Get(int Id);
    }
}
