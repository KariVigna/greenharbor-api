using System.Linq.Expressions;
using GreenHarborApi.Interfaces;
using GreenHarborApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenHarborApi.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected GreenHarborApiContext RepositoryContext { get; set; }

        public RepositoryBase(GreenHarborApiContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>()
            .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>()
            .Where(expression)
            .AsNoTracking();
        }
    }
}