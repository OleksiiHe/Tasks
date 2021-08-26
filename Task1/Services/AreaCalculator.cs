using System;

namespace Task1
{
    public class AreaCalculator
    {
        private const double _pi = Math.PI;

        private double? A;

        public double? GetEllipseArea(Ellipse ellipse)
        {
            double? a = ellipse.MajorRadiusA;
            double? b = ellipse.MinorRadiusB;

            A = ellipse.Area;

            // Ellipse Area(S) Formula
            A = _pi * a * b;

            return A;
        }

        public double? GetRectangleArea(Rectangle rectangle)
        {
            double? l = rectangle.LengthL;
            double? w = rectangle.WidthW;

            A = rectangle.Area;

            // Rectangle Area(A) Formula
            A = w * l;

            return A;
        }

        public double? GetTrapezoidArea(Trapezoid trapezoid)
        {
            double? a = trapezoid.BaseA;
            double? b = trapezoid.BaseB;
            double? h = trapezoid.HeightToB;

            A = trapezoid.Area;

            // Trapezoid Area(A) Formula
            A = (a + b) / 2 * h;

            return A;
        }

        public double? GetTriangleArea(Triangle triangle)
        {
            double? b = triangle.BaseB;
            double? h = triangle.HeightToB;

            A = triangle.Area;

            // Triangle Area(A) Formula
            A = h * b / 2;

            return A;
        }
    }
}
