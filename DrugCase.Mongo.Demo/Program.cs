using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugCase.Mongo.Demo
{
    public class user
    {
          public string Name { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var server = ConfigurationManager.AppSettings["MongoDbServer"].ToString();
            var client = new MongoClient(server);
            var database = client.GetDatabase("aehyok");
            var sss = database.GetCollection<user>("user").Find(x=>x.Name=="aehyok");
        }
    }
}
