namespace Task1
{
    public class Trapezoid : FigureBase, ICalculator  //TODO: Fix type to double
    {
        /// <summary>
        /// A is Base
        /// B is Base
        /// C is Side
        /// D is Side
        /// H is Height to B
        /// </summary>
        public double? A { get; set; }
        public double? B { get; set; }
        public double? C { get; set; }
        public double? D { get; set; }
        public double? H { get; set; }

        public double? GetArea()
        {
            Area = (A + B) / 2 * H;

            return Area;
        }

        public double? GetPerimeter()
        {
            Perimeter = A + B + C + D;

            return Perimeter;
        }
    }
}
