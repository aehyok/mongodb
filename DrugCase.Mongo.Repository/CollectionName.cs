using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugCase.Mongo.Repository
{
    /// <summary>
    /// added by lqm 20161022  http://www.cnblogs.com/hyddd/archive/2009/07/20/1526777.html
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class CollectionName : Attribute
    {
        public CollectionName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("空的集合名称", "value");
            this.Name = value;
        }

        public virtual string Name { get; private set; }
    }
}
