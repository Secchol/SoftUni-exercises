﻿using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
        }
    }
}
