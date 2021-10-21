using System;

namespace Task1
{
    public class Ellipse : FigureBase, ICalculator
    {
        /// <summary>
        /// A is MajorRadius.
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// B is MinorRadius.
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Ellipse Area calculation by formula:
        /// Area = PI * MajorRadius * MinorRadius
        /// </summary>
        public double GetArea()
        {
            Area = Math.PI * A * B;

            return Area;
        }

        /// <summary>
        /// Ellipse Perimeter calculation by formula:
        /// Perimeter = 4 * ((PI * MajorRadius * MinorRadius + Pow(MajorRadius - MinorRadius, 2)) / (MajorRadius + MinorRadius))
        /// </summary>
        public double GetPerimeter()
        {
            //Perimeter = 4 * ((_pi * a * b + Math.Pow((double)(a - b), 2)) / (a + b));
            Perimeter = 4 * (((Math.PI * A * B) + Math.Pow(A - B, 2)) / (A + B));

            return Perimeter;
        }
    }
}
