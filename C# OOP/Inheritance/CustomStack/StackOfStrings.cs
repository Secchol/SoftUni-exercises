using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (Count == 0)
                return true;
            return false;


        }
        public void AddRange(IEnumerable<string> input)
        {
            foreach (var item in input)
            {
                this.Push(item);

            }



        }
    }
}
