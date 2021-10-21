namespace Task1
{
    public class Rectangle : ICalculator
    {
        /// <summary>
        /// L is Length
        /// </summary>
        public double L { get; set; }

        /// <summary>
        /// W is Width
        /// </summary>
        public double W { get; set; }

        /// <summary>
        /// Rectangle Area calculation by formula:
        /// Area = Length * Width
        /// </summary>
        public double GetArea()
        {
            return W * L;
        }

        /// <summary>
        /// Rectangle Perimeter calculation by formula:
        /// Perimeter = 2 * (Length + Width)
        /// </summary>
        public double GetPerimeter()
        {
            return 2 * (L + W);
        }
    }
}
