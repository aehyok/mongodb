using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.GridFS;

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
                //var query = new QueryDocument { { "CustomerName", "中科软3" } };
                var query = new QueryDocument { { "CustomerId", new ObjectId("9cc11fa2aa7f400aba9a0649") } };
                var list = CustomerHelper.Find(query);
                #endregion

                CustomerHelper.Delete(new ObjectId("7f10ea7d8abf4c0285620f49"));



                MongoServerSettings mongoSetting = new MongoServerSettings();
                mongoSetting.MaxConnectionPoolSize = 15000;//设定最大连接池
                mongoSetting.WaitQueueSize = 500;//设定等待队列数
                mongoSetting.Server = new MongoServerAddress("192.168.1.176", 27017);
                int count = MongoServer.MaxServerCount;
                MongoServer mongo=new MongoServer(mongoSetting);
                
                MongoDatabase dataBase = mongo.GetDatabase(ConfigHelper.DataBaseName);
                MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "DocPdf" };

                //实例化一个GridFS
                MongoGridFS gridfs = new MongoGridFS(dataBase, fsSetting);

                //将本地文件上传到mongoDB中去,以默认块的大小256KB对文件进行分块
                //gridfs.Upload("100100.pdf", "Test.pdf");




                //获取文件值
                string moFileName = "Test.pdf";
                //获取图片名
                //通过文件名去数据库查值
                MongoGridFS fs = new MongoGridFS(dataBase, fsSetting);
                MongoGridFSFileInfo gfInfo = new MongoGridFSFileInfo(fs, moFileName);
                //方法一，很简洁
                string fileName = Guid.NewGuid().ToString() + ".pdf";
                fs.Download(fileName, moFileName);
                Console.ReadLine();

            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}
