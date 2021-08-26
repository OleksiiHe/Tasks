namespace Task1
{
    public class FigureBuilder
    {
        private AreaCalculator _areaCalculator = new AreaCalculator();
        private PerimeterCalculator _perimeterCalculator = new PerimeterCalculator();

        public FigureBase figureBase;

        public FigureBuilder(EllipseViewModel ellipseViewModel)
        {
            Ellipse ellipse = new Ellipse
            {
                MajorRadiusA = ellipseViewModel.MajorRadiusA,
                MinorRadiusB = ellipseViewModel.MinorRadiusB,
            };

            ellipse.Area = _areaCalculator.GetEllipseArea(ellipse);
            ellipse.Perimeter = _perimeterCalculator.GetEllipsePerimeter(ellipse);

            figureBase = (FigureBase)ellipse;
        }

        public FigureBuilder(RectangleViewModel rectangleViewModel)
        {
            Rectangle rectangle = new Rectangle
            {
                LengthL = rectangleViewModel.LengthL,
                WidthW = rectangleViewModel.WidthW,
            };

            rectangle.Area = _areaCalculator.GetRectangleArea(rectangle);
            rectangle.Perimeter = _perimeterCalculator.GetRectanglePerimeter(rectangle);

            figureBase = (FigureBase)rectangle;
        }

        public FigureBuilder(TrapezoidViewModel trapezoidViewModel)
        {
            Trapezoid trapezoid = new Trapezoid
            {
                BaseA = trapezoidViewModel.BaseA,
                BaseB = trapezoidViewModel.BaseB,
                SideC = trapezoidViewModel.SideC,
                SideD = trapezoidViewModel.SideD,
                HeightToB = trapezoidViewModel.HeightToB 
            };

            trapezoid.Area = _areaCalculator.GetTrapezoidArea(trapezoid);
            trapezoid.Perimeter = _perimeterCalculator.GetTrapezoidPerimeter(trapezoid);

            figureBase = (FigureBase)trapezoid;
        }

        public FigureBuilder(TriangleViewModel triangleViewModel)
        {
            Triangle triangle = new Triangle
            {
                SideA = triangleViewModel.SideA,
                BaseB = triangleViewModel.BaseB,
                SideC = triangleViewModel.SideC,
                HeightToB = triangleViewModel.HeightToB
            };

            triangle.Area = _areaCalculator.GetTriangleArea(triangle);
            triangle.Perimeter = _perimeterCalculator.GetTrianglePerimeter(triangle);

            figureBase = (FigureBase)triangle;
        }
    }
}

