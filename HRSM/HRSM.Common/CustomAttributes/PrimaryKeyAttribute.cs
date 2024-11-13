using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.Common.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute(string primaryKey)
        {
            this.Name = primaryKey;
        }

        public string Name { get; protected set; }
        public bool autoIncrement = false;

    } 
}
