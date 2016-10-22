using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DrugCase.Mongo.Demo
{
    public class Customer
    {
        public ObjectId _id { get; set; }
        public ObjectId CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Telephone { get; set; }
    }
}
