using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : ICollection, IRemovable
    {
        public AddRemoveCollection()
        {
            Collection = new string[0];

        }
        public string[] Collection { get; set; }

        public int Add(string element)
        {
            string[] newCollection = new string[this.Collection.Length + 1];
            newCollection[0] = element;
            this.Collection.CopyTo(newCollection, 1);
            this.Collection = newCollection;
            return 0;
        }

        public virtual string Remove()
        {
            string[] newCollection = new string[this.Collection.Length - 1];
            for (int i = 0; i < this.Collection.Length - 1; i++)
            {
                newCollection[i] = this.Collection[i];
            }
            string removedElement = this.Collection[this.Collection.Length - 1];
            this.Collection = newCollection;
            return removedElement;
        }
    }
}
