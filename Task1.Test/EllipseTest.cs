using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Task1.Test
{
    [TestClass]
    public class EllipseTest
    {
        private MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

        private string assemblyName = typeof(MainWindowViewModel).Assembly.GetName().Name;

        Figures figureType = Figures.Ellipse;

        private static IEnumerable<object[]> GetValidTestDataForArea()
        {
            return new List<object[]>()
            {
                new object[]{ 0.1, 0.03142 },
                new object[]{ 1.0, 3.14159 },
                new object[]{ 99, 30790.7496 },
            };
        }

        [TestMethod]
        [DynamicData(nameof(GetValidTestDataForArea), DynamicDataSourceType.Method)]
        public void GetArea_WhenValidData_ShouldCorrectEllipseArea(double input, double result)
        {
            // Arrange
            var _viewModelPath = $"{assemblyName}.{Enum.GetName(typeof(Figures), figureType)}ViewModel";
            var FigureViewModel = Activator.CreateInstance(assemblyName, _viewModelPath).Unwrap();

            (FigureViewModel as EllipseViewModel).MajorRadiusA = input;
            (FigureViewModel as EllipseViewModel).MinorRadiusB = input;

            double expected = result;

            // Act
            double actual = (FigureViewModel as IBuilder).GetFigure().GetArea();

            // Assert
            Assert.AreEqual(expected, actual, 0.001, "Parameter not calculated correctly");
        }

        private static IEnumerable<object[]> GetValidTestDataForPerimeter()
        {
            return new List<object[]>()
            {
                new object[]{ 0.1, 0.62832 },
                new object[]{ 1.0, 6.28319 },
                new object[]{ 99, 622.03535 },
            };
        }

        [TestMethod]
        [DynamicData(nameof(GetValidTestDataForPerimeter), DynamicDataSourceType.Method)]
        public void GetPerimeter_WhenValidData_ShouldCorrectEllipsePerimeter(double input, double result)
        {
            // Arrange
            var _viewModelPath = $"{assemblyName}.{Enum.GetName(typeof(Figures), figureType)}ViewModel";
            var FigureViewModel = Activator.CreateInstance(assemblyName, _viewModelPath).Unwrap();

            (FigureViewModel as EllipseViewModel).MajorRadiusA = input;
            (FigureViewModel as EllipseViewModel).MinorRadiusB = input;

            double expected = result;

            // Act
            double actual = (FigureViewModel as IBuilder).GetFigure().GetPerimeter();

            // Assert
            Assert.AreEqual(expected, actual, 0.001, "Parameter not calculated correctly");
        }
    }
}
