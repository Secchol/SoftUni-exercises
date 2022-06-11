using System;
using System.Collections.Generic;
using System.Text;

namespace MyTuple
{
    public class MyTuple<TFirst, TSecond, TThird>
    {
        public MyTuple(TFirst first, TSecond second, TThird third)
        {
            First = first;
            Second = second;
            Third = third;



        }
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
        public TThird Third { get; set; }
        public override string ToString()
        {
            return $"{this.First} -> {this.Second} -> {this.Third}";
        }
    }
}
