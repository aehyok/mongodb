using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugCase.Mongo.Demo
{
    /// <summary>
    /// 初始化配置文件数据
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// MongoDb数据链链接地址
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// MongoDb数据库
        /// </summary>
        public static string DataBaseName { get; set; }

        /// <summary>
        /// 初始化配置文件数据
        /// </summary>
        public static void Init()
        {
            ConnectionString = ConfigurationManager.AppSettings["MongoDbServer"];
            DataBaseName = ConfigurationManager.AppSettings["DataBaseName"];

        }
    }
}
