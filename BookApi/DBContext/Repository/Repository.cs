using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookApi.DBContext.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BookContext _context;

        public Repository(BookContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            return null;
        }

        public async Task<TEntity> GetById(string id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            return null;
        }

        public async Task<TEntity> GetById(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity != null)
            {
                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        _context.Entry(entity).Reference(include).Load();
                    }
                }
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }


        public async Task<TEntity> GetById(string id, params Expression<Func<TEntity, object>>[] includes)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity != null)
            {
                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        _context.Entry(entity).Reference(include).Load();
                    }
                }
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public TEntity Update(TEntity entity)
        {

            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
