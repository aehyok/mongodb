using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DrugCase.Mongo.Repository
{
    public class MongoRepository<T, TKey> : IRepository<T, TKey>
        where T : IEntity<TKey>
    {
        protected internal IMongoCollection<T> collection;

        public MongoRepository()
            : this(Util<TKey>.GetDefaultConnectionString())
        {
        }

        public MongoRepository(string connectionString)
        {
            this.collection = Util<TKey>.GetCollectionFromConnectionString<T>(connectionString);
        }

        public MongoRepository(string connectionString, string collectionName)
        {
            this.collection = Util<TKey>.GetCollectionFromConnectionString<T>(connectionString, collectionName);
        }

        public MongoRepository(MongoUrl url)
        {
            this.collection = Util<TKey>.GetCollectionFromUrl<T>(url);
        }

        public MongoRepository(MongoUrl url, string collectionName)
        {
            this.collection = Util<TKey>.GetCollectionFromUrl<T>(url, collectionName);
        }

        public IMongoCollection<T> Collection
        {
            get { return this.collection; }
        }

        //public string CollectionName
        //{
        //    get { return this.collection.Name; }
        //}

        public T GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            this.collection.InsertOne(entity);

            return entity;
        }

        public void Add(IEnumerable<T> entities)
        {
            this.collection.InsertMany(entities);
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            this.collection.DeleteOne(filter);
        }

        public void Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", entity.Id);
            this.collection.DeleteOne(filter);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            this.collection.DeleteOne(predicate);
        }

        public void DeleteAll()
        {
            this.collection.DeleteMany(new BsonDocument());
        }

        public long Count()
        {
            return this.collection.Count(new BsonDocument());
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IDisposable RequestStart()
        {
            throw new NotImplementedException();
        }

        public void RequestDone()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Type ElementType
        {
            get { throw new NotImplementedException(); }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }
    }
}
