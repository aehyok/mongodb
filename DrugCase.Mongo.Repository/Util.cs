using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DrugCase.Mongo.Repository
{
    internal static class Util<U>
    {
        private const string DefaultConnectionstringName = "MongoDBServer";

        public static string GetDefaultConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[DefaultConnectionstringName].ConnectionString;
        }

        private static IMongoDatabase GetDatabaseFromUrl(MongoUrl url)
        {
            var client = new MongoClient(url);
            //var server = client.GetServer();  //old version
            return client.GetDatabase(url.DatabaseName);
        }

        public static IMongoCollection<T> GetCollectionFromConnectionString<T>(string connectionString)
    where T : IEntity<U>
        {
            return GetCollectionFromConnectionString<T>(connectionString, GetCollectionName<T>());
        }

        public static IMongoCollection<T> GetCollectionFromConnectionString<T>(string connectionString, string collectionName)
    where T : IEntity<U>
        {
            return GetDatabaseFromUrl(new MongoUrl(connectionString))
                .GetCollection<T>(collectionName);
        }

        public static IMongoCollection<T> GetCollectionFromUrl<T>(MongoUrl url)
    where T : IEntity<U>
        {
            return GetCollectionFromUrl<T>(url, GetCollectionName<T>());
        }

        public static IMongoCollection<T> GetCollectionFromUrl<T>(MongoUrl url, string collectionName)
    where T : IEntity<U>
        {
            return GetDatabaseFromUrl(url)
                .GetCollection<T>(collectionName);
        }

        private static string GetCollectionName<T>() where T : IEntity<U>
        {
            var collectionName = typeof(T).BaseType == typeof(object) ? GetCollectioNameFromInterface<T>() : GetCollectionNameFromType(typeof(T));

            if (string.IsNullOrEmpty(collectionName))
            {
                throw new ArgumentException("Collection name cannot be empty for this entity");
            }
            return collectionName;
        }

        private static string GetCollectioNameFromInterface<T>()
        {
            var attribute = Attribute.GetCustomAttribute(typeof(T), typeof(CollectionName));
            var collectionname = attribute != null ? ((CollectionName)attribute).Name : typeof(T).Name;
            return collectionname;
        }

        private static string GetCollectionNameFromType(Type entitytype)
        {
            string collectionname;
            var att = Attribute.GetCustomAttribute(entitytype, typeof(CollectionName));
            if (att != null)
            {
                collectionname = ((CollectionName)att).Name;
            }
            else
            {
                if (typeof(Entity).IsAssignableFrom(entitytype))
                {
                    while (entitytype.BaseType != null && !(entitytype.BaseType == typeof(Entity)))
                    {
                        entitytype = entitytype.BaseType;
                    }
                }
                collectionname = entitytype.Name;
            }
            return collectionname;
        }
    }
}
