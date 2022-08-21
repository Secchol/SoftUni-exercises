using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IRemovable, ICollection
    {
        public MyList()
        {
            Collection = new string[0];


        }
        public int Used => this.Collection.Length;
        public override string Remove()
        {
            string removedElement = this.Collection[0];
            string[] newCollection = new string[this.Collection.Length - 1];
            for (int i = 1; i < this.Collection.Length; i++)
            {
                newCollection[i - 1] = this.Collection[i];
            }
            this.Collection = newCollection;
            return removedElement;
        }
    }
}
