using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DrugCase.Mongo.Repository
{
    /// <summary>
    ///仓储接口 added by aehyok 20161022
    /// </summary>
    public interface IRepository<T, in TKey> : IQueryable<T>
        where T : IEntity<TKey>
    {
        IMongoCollection<T> Collection { get; }

        T GetById(TKey id);

        T Add(T entity);

        void Add(IEnumerable<T> entities);

        T Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(TKey id);

        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);

        void DeleteAll();

        long Count();

        bool Exists(Expression<Func<T, bool>> predicate);

        IDisposable RequestStart();

        void RequestDone();
    }
}
