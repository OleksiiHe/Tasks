using System;

namespace Task1
{
    public class Ellipse : FigureBase, ICalculator //TODO: After fix type to double, use Math.Pow
    {
        /// <summary>
        /// A is MajorRadius
        /// B is MinorRadius
        /// </summary>
        public double? A { get; set; }
        public double? B { get; set; }

        public double? GetArea()
        {
            Area = Math.PI * A * B;
            
            return Area;
        }

        public double? GetPerimeter()
        {
            //Perimeter = 4 * ((_pi * a * b + Math.Pow((double)(a - b), 2)) / (a + b));
            Perimeter = 4 * ((Math.PI * A * B + (A - B) * (A - B)) / (A + B));

            return Perimeter;
        }
    }
}
