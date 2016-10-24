using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace DrugCase.Mongo.Demo
{
    public class UploadHelper
    {
        /// <summary>
        /// 上传文件测试方法
        /// </summary>
        /// <returns></returns>
        public static bool Upload()
        {
            MongoServerSettings mongoSetting = new MongoServerSettings();
            mongoSetting.MaxConnectionPoolSize = 15000;//设定最大连接池
            mongoSetting.WaitQueueSize = 500;//设定等待队列数
            mongoSetting.Server = new MongoServerAddress("192.168.1.176", 27017);
            MongoServer mongo = new MongoServer(mongoSetting);

            MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "DocPdf" };

            //实例化一个GridFS
            MongoGridFS gridfs = new MongoGridFS(mongo, ConfigHelper.DataBaseName, fsSetting);

            //将本地文件上传到mongoDB中去,以默认块的大小256KB对文件进行分块
            gridfs.Upload("100100.pdf", "Test.pdf");
            return true;
        }

        public static bool DownLoad()
        {
            MongoServerSettings mongoSetting = new MongoServerSettings();
            mongoSetting.MaxConnectionPoolSize = 15000;//设定最大连接池
            mongoSetting.WaitQueueSize = 500;//设定等待队列数
            mongoSetting.Server = new MongoServerAddress("192.168.1.176", 27017);
            MongoServer mongo = new MongoServer(mongoSetting);

            MongoDatabase dataBase = mongo.GetDatabase(ConfigHelper.DataBaseName);
            MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "DocPdf" };





            //获取文件值
            string moFileName = "Test.pdf";
            //获取图片名
            //通过文件名去数据库查值
            MongoGridFS fs = new MongoGridFS(dataBase, fsSetting);
            MongoGridFSFileInfo gfInfo = new MongoGridFSFileInfo(fs, moFileName);
            //方法一，很简洁
            string fileName = Guid.NewGuid().ToString() + ".pdf";
            fs.Download(fileName, moFileName);
        }
    }
}
