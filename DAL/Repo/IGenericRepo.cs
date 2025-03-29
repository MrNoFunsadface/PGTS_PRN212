using System.Linq.Expressions;

namespace DAL.Repo
{
    public interface IGenericRepo<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(string id);
        public bool Create(T entity);
        public bool Update(T entity);
        public bool Delete(T entity);
        public void Save();
        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    }
}
