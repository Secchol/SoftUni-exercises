﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public virtual string ProduceSound()
        {
            return string.Empty;


        }
    }
}
