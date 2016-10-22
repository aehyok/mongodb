using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DrugCase.Mongo.Demo
{
    public class CustomerHelper
    {
        public static void Insert(Customer customer)
        {
            customer.CustomerId = new ObjectId(Guid.NewGuid().ToString("N"));

            // 首先创建一个连接
            MongoClient mongo = new MongoClient(ConfigHelper.ConnectionString);
            var dataBase=mongo.GetDatabase(ConfigHelper.DataBaseName);

            // 根据类型获取相应的集合
            var collection = dataBase.GetCollection<Customer>("Customer");
                // 向集合中插入对象
            collection.InsertOne(customer);
        }


        public static void Delete(ObjectId customerId)
        {
            MongoClient mongo = new MongoClient(ConfigHelper.ConnectionString);
            var dataBase = mongo.GetDatabase(ConfigHelper.DataBaseName);
            var collection = dataBase.GetCollection<Customer>("Customer");
            collection.DeleteOne(item => item.CustomerId == customerId);  //唯一Id确保只删除一条记录
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="customer"></param>
        public static void Update(Customer customer)
        {
            MongoClient mongo = new MongoClient(ConfigHelper.ConnectionString);
            var dataBase = mongo.GetDatabase(ConfigHelper.DataBaseName);
            var collection = dataBase.GetCollection<Customer>("Customer");
            var filter = Builders<Customer>.Filter.Eq("CustomerId", customer.CustomerId);
            var update = Builders<Customer>.Update
                .Set("CustomerName", "腾讯科技")
                .Set("Telephone","1389999999")
                .CurrentDate("lastModified");
            collection.UpdateOne(filter,update);
        }

        public static List<Customer> Find(QueryDocument query)
        {
            MongoClient mongo = new MongoClient(ConfigHelper.ConnectionString);
            var dataBase = mongo.GetDatabase(ConfigHelper.DataBaseName);
            var collection = dataBase.GetCollection<Customer>("Customer");
            List<Customer> list = collection.Find(query).ToList();
            return list;
        }
    }
}
