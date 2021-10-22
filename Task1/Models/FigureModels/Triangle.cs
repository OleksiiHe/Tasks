namespace Task1
{
    public class Triangle : FigureBase, ICalculator
    {
        /// <summary>
        /// A is Side.
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// B is Base.
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// C is Side.
        /// </summary>
        public double C { get; set; }

        /// <summary>
        /// H is Height to B.
        /// </summary>
        public double H { get; set; }

        /// <summary>
        /// Triangle Area calculation by formula:
        /// Area = Height * Base / 2
        /// </summary>
        public double GetArea()
        {
            Area = H * B / 2;

            return Area;
        }

        /// <summary>
        /// Triangle Perimeter calculation by formula:
        /// Perimeter = SideA + BaseB + SideC
        /// </summary>
        public double GetPerimeter()
        {
            Perimeter = A + B + C;

            return Perimeter;
        }
    }
}
