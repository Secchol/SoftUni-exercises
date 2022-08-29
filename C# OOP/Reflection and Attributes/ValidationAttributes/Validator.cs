using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool isValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties().Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any()).ToArray();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(obj);
                MyValidationAttribute attribute = propertyInfo.GetCustomAttribute<MyValidationAttribute>();
                bool isValid = attribute.isValid(value);
                if (!isValid)
                    return false;


            }
            return true;



        }
    }
}
