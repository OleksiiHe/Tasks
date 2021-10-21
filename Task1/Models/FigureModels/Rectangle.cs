namespace Task1
{
    public class Rectangle : FigureBase, ICalculator
    {
        /// <summary>
        /// L is Length.
        /// </summary>
        public double L { get; set; }

        /// <summary>
        /// W is Width.
        /// </summary>
        public double W { get; set; }

        /// <summary>
        /// Rectangle Area calculation by formula:
        /// Area = Length * Width
        /// </summary>
        public double GetArea()
        {
            Area = W * L;

            return Area;
        }

        /// <summary>
        /// Rectangle Perimeter calculation by formula:
        /// Perimeter = 2 * (Length + Width)
        /// </summary>
        public double GetPerimeter()
        {
            Perimeter = 2 * (L + W);

            return Perimeter;
        }
    }
}
