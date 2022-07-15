using System.Linq.Expressions;
using DataAccess.Context;
using Entity.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public void Add(TEntity entity)
    {
        using (MovieContext context = new MovieContext())
        {
            var addedEntity =context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        using (MovieContext context = new MovieContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        using (MovieContext context = new MovieContext())
        {
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using (MovieContext context = new MovieContext())
        {
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }

    public void Update(TEntity entity)
    {
        using (MovieContext context = new MovieContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
            
    }
}