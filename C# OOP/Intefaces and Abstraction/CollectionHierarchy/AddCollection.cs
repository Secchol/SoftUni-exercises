using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : ICollection
    {
        public AddCollection()
        {
            Collection = new string[0];

        }
        public string[] Collection { get; set; }

        public int Add(string element)
        {
            string[] newCollection = new string[this.Collection.Length + 1];
            this.Collection.CopyTo(newCollection, 0);
            newCollection[this.Collection.Length] = element;
            int indexAdded = this.Collection.Length;
            this.Collection = newCollection;
            return indexAdded;
        }
    }
}
