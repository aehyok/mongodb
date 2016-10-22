using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DrugCase.Mongo.Repository
{
    /// <summary>
    /// added by aehyok 20161022
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey>
    {
        //[BsonId]
        TKey Id { get; set; }

        ObjectId _id { get; set; }
    }

    /// <summary>
    /// 默认一个字符串类型的
    /// </summary>
    public interface IEntity : IEntity<string>
    {
    }
}
