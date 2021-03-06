namespace Task1
{
    public class Trapezoid : ICalculator
    {
        /// <summary>
        /// A is Base.
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
        /// D is Side.
        /// </summary>
        public double D { get; set; }

        /// <summary>
        /// H is Height to B.
        /// </summary>
        public double H { get; set; }

        /// <summary>
        /// Trapezoid Area calculation by formula:
        /// Area = (BaseA + BaseB) / 2 * Height
        /// </summary>
        public double GetArea()
        {
            return (A + B) / 2 * H;
        }

        /// <summary>
        /// Trapezoid Perimeter calculation by formula:
        /// Perimeter = BaseA + BaseB + SideC + SideD
        /// </summary>
        public double GetPerimeter()
        {
            return A + B + C + D;
        }
    }
}
