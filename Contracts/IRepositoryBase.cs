using Entities.Models;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        void Delete(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<T> GetByIdAsync(Guid id, bool trackChanges);
        void Update(T entity);
    }
}