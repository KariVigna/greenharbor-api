using System.Linq.Expressions;

namespace GreenHarborApi.Interfaces
{
  public interface IRepositoryBase<T>
  {
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
  }
}