namespace Task1
{
    public class Triangle : FigureBase, ICalculator //TODO: Fix type to double
    {
        /// <summary>
        /// A is Side
        /// B is Base
        /// C is Side
        /// H is Height to B
        /// </summary>
        public double? A { get; set; }
        public double? B { get; set; }
        public double? C { get; set; }
        public double? H { get; set; }

        public double? GetArea()
        {
            Area = H * B / 2;

            return Area;
        }

        public double? GetPerimeter()
        {
            Perimeter = A + B + C;

            return Perimeter;
        }
    }
}
