using System;

namespace Task1
{
    public class PerimeterCalculator
    {
        private const double _pi = Math.PI;

        private double P;
        private double L;

        public double GetEllipsePerimeter(Ellipse ellipse)
        {
            double a = ellipse.MajorRadiusA;
            double b = ellipse.MinorRadiusB;

            L = ellipse.Perimeter;

            // Ellipse Perimeter(L) Formula 
            L = 4 * ((_pi * a * b + Math.Pow(a - b, (double)2)) / (a + b));

            return L;
        }

        public double GetRectanglePerimeter(Rectangle rectangle)
        {
            double l = rectangle.LengthL;
            double w = rectangle.WidthW;

            P = rectangle.Perimeter;

            // Rectangle Perimeter(P) Formula
            P = 2 * (l + w);

            return P;
        }

        public double GetTrapezoidPerimeter(Trapezoid trapezoid)
        {
            double a = trapezoid.BaseA;
            double b = trapezoid.BaseB;
            double c = trapezoid.SideC;
            double d = trapezoid.SideD;

            P = trapezoid.Perimeter;

            // Trapezoid Perimeter(P) Formula
            P = a + b + c + d;

            return P;
        }

        public double GetTrianglePerimeter(Triangle triangle)
        {
            double a = triangle.SideA;
            double b = triangle.BaseB;
            double c = triangle.SideC;

            P = triangle.Perimeter;

            // Triangle Perimeter(P) Formula
            P = a + b + c;

            return P;
        }
    }
}
