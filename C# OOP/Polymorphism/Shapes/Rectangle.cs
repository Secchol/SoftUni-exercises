﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;


        }
        public double Height
        {
            get => this.height;
            set => height = value;

        }
        public double Width
        {
            get => this.width;
            set => width = value;

        }


        public override double CalculatePerimeter()
        {
            return 2 * (height + width);
        }
        public override double CalculateArea()
        {
            return height * width;
        }
        public override string Draw()
        {
            return base.Draw() + $"{this.GetType().Name}";
        }
    }
}
