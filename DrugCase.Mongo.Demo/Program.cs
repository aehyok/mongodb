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
            //初始化配置文件
            ConfigHelper.Init();

            try
            {
                //#region 插入数据测试(注意数据量是100W条)
                //int start=Environment.TickCount;
                //for (int index = 0; index < 1000000; index++)
                //{
                //    Customer customer = new Customer()
                //    {
                //        Address = "深圳南山区",
                //        ContactName = "0755-12345678",
                //        CustomerName = "中科软" + (index + 1).ToString(),
                //        PostalCode = "518000",
                //        Telephone = "1388888888888"
                //    };
                //    CustomerHelper.Insert(customer);
                //}
                //int end = Environment.TickCount;
                //Console.WriteLine("10000行数据处理耗时" + (end - start).ToString() + "ms");
                //#endregion

                #region 更新
                //Customer customer = new Customer()
                //{
                //    Address = "深圳南山区",
                //    ContactName = "0755-12345678",
                //    CustomerName = "腾讯科技",
                //    PostalCode = "518000",
                //    Telephone = "1389999999",
                //    CustomerId = "c57e40ea343b4154ae3641e224525602"
                //};

                //CustomerHelper.Update(customer);
                #endregion


                #region 查询
                ////var query = new QueryDocument { { "CustomerName", "中科软3" } };
                //var query = new QueryDocument { { "CustomerId", new ObjectId("9cc11fa2aa7f400aba9a0649") } };
                //var list = CustomerHelper.Find(query);
                #endregion

                CustomerHelper.Delete(new ObjectId("7f10ea7d8abf4c0285620f49"));
                Console.ReadLine();

            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}
