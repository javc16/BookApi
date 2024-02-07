using System.Linq.Expressions;

namespace BookApi.DBContext.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<TEntity> GetById(string id);

        Task<TEntity> GetById(int id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetById(string id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        void Add(TEntity entity);
        TEntity Update(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void SaveChanges();
    }
}
