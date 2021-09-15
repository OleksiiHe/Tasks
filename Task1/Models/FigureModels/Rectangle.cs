namespace Task1
{
    public class Rectangle : FigureBase, ICalculator  //TODO: Fix type to double
    {
        /// <summary>
        /// L is Length
        /// W is Width
        /// </summary>
        public double? L { get; set; }
        public double? W { get; set; }

        public double? GetArea()
        {
            Area = W * L;

            return Area;
        }

        public double? GetPerimeter()
        {
            Perimeter = 2 * (L + W);

            return Perimeter;
        }
    }
}
