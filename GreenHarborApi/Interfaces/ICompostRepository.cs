using GreenHarborApi.Models;

namespace GreenHarborApi.Interfaces
{
  public interface ICompostRepository : IRepositoryBase<Compost>
  {
    PagedList<Compost> GetComposts(PagedParameters compostParameters);
    Compost GetCompostById(Guid compostId);
  }
}