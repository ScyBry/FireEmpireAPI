using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
{
    protected RepositoryContext RepositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges
            ? RepositoryContext.Set<T>().Where(expression).AsNoTracking()
            : RepositoryContext.Set<T>().Where(expression);

    public async Task<T> GetByIdAsync(Guid id, bool trackChanges) =>
        await FindByCondition(e => e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

    public async Task CreateAsync(T entity) =>
        await RepositoryContext.Set<T>().AddAsync(entity);

    public void Update(T entity) =>
        RepositoryContext.Set<T>().Update(entity);

    public void Delete(T entity) =>
        entity.isDeleted = true;

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression) =>
        await RepositoryContext.Set<T>().AnyAsync(expression);
}