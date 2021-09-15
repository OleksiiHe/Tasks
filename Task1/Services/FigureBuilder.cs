using System;

namespace Task1
{
    public class FigureBuilder //TODO: Add Validation
    {
        public ICalculator figureBase;

        public FigureValidator validator = new FigureValidator();

        public FigureBuilder(EllipseViewModel ellipseViewModel)
        {
            if (!validator.IsEmpty(ellipseViewModel.MajorRadiusA, ellipseViewModel.MinorRadiusB)
                && !validator.IsOutOfRange(ellipseViewModel.MajorRadiusA, ellipseViewModel.MinorRadiusB))
            {
                Ellipse ellipse = new Ellipse
                {
                    A = ellipseViewModel.MajorRadiusA,
                    B = ellipseViewModel.MinorRadiusB,
                };

                figureBase = (ICalculator)ellipse;
            }
        }

        public FigureBuilder(RectangleViewModel rectangleViewModel)
        {
            Rectangle rectangle = new Rectangle
            {
                L = rectangleViewModel.LengthL,
                W = rectangleViewModel.WidthW,
            };

            figureBase = (ICalculator)rectangle;
        }

        public FigureBuilder(TrapezoidViewModel trapezoidViewModel)
        {
            Trapezoid trapezoid = new Trapezoid
            {
                A = trapezoidViewModel.BaseA,
                B = trapezoidViewModel.BaseB,
                C = trapezoidViewModel.SideC,
                D = trapezoidViewModel.SideD,
                H = trapezoidViewModel.HeightToB 
            };

            figureBase = (ICalculator)trapezoid;
        }

        public FigureBuilder(TriangleViewModel triangleViewModel)
        {
            Triangle triangle = new Triangle
            {
                A = triangleViewModel.SideA,
                B = triangleViewModel.BaseB,
                C = triangleViewModel.SideC,
                H = triangleViewModel.HeightToB
            };

            figureBase = (ICalculator)triangle;
        }
    }
}

