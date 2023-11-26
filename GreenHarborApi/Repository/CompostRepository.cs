using GreenHarborApi.Models;
using GreenHarborApi.Interfaces;


namespace GreenHarborApi.Repository
{
  public class CompostRepository : RepositoryBase<Compost>, ICompostRepository
  {
    public CompostRepository(GreenHarborApiContext repositoryContext)
        : base(repositoryContext)
      {
      }

      public PagedList<Compost> GetComposts(PagedParameters compostParameters)
      {

          return PagedList<Compost>.ToPagedList(FindAll(),
            compostParameters.PageNumber,
            compostParameters.PageSize);
      }

      public Compost GetCompostById(Guid compostId)
      {
          return FindByCondition(compost => compost.CompostId.Equals(compostId))
          .DefaultIfEmpty(new Compost())
          .FirstOrDefault();
      }
  }   
}
  



