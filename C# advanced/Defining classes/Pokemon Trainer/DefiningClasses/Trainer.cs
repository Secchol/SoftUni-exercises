using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadgets { get; set; }
        public HashSet<Pokemon> Pokemon { get; set; }
        public Trainer()
        {
            this.NumberOfBadgets = 0;
            this.Pokemon = new HashSet<Pokemon>();


        }
    }
}
