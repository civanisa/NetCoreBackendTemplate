using Core.Entities;
using Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        #region Ctor
        private Paginate<TEntity> paginate;

        public EfEntityRepositoryBase()
        {
            this.paginate = new Paginate<TEntity>();
        }
        #endregion

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
                return context.Set<TEntity>().SingleOrDefault(filter);
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
        }
        public List<TEntity> PaginateAllReturnList(Pageable pageable, Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
                return filter == null
                    ? context.Set<TEntity>()
                        .Skip(pageable.Size * pageable.Page)
                        .Take(pageable.Size)
                        .ToList()
                    : context.Set<TEntity>()
                        .Where(filter)
                        .Skip(pageable.Size * pageable.Page)
                        .Take(pageable.Size)
                        .ToList();
        }
        public IPaginate<TEntity> PaginateAll(Pageable pageable, Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
                return filter == null
                    ? paginate.MakePagination(EfPaginate(context, pageable), pageable, EfCount(context))
                    : paginate.MakePagination(EFPaginateAndFilter(context, pageable, filter), pageable, EfCount(context));
        }

        private List<TEntity> EfPaginate(TContext context, Pageable pageable)
        {
            return context.Set<TEntity>()
                            .Skip(pageable.Size * pageable.Page)
                            .Take(pageable.Size)
                            .ToList();
        }
        private List<TEntity> EFPaginateAndFilter(TContext context, Pageable pageable, Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>()
                            .Where(filter)
                            .Skip(pageable.Size * pageable.Page)
                            .Take(pageable.Size)
                            .ToList();
        }
        private int EfCount(TContext context)
        {
            return context.Set<TEntity>().Count();
        }

    }
}
