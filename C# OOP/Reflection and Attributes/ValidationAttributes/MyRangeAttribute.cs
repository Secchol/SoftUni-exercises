﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;


        }
        public override bool isValid(object obj)
        {
            int currentValue = (int)obj;
            return currentValue > minValue && currentValue < maxValue;



        }
    }
}
