using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface ICollection
    {
        string[] Collection { get; set; }
        public int Add(string item);
    }
}
