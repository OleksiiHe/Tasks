using System;
using System.Windows.Input;

namespace Task1
{
    class CalculateCommand : ICommand
    {
        public double result;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public CalculateCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {

                switch((_mainWindowViewModel.FigureType, _mainWindowViewModel.FormulaType))
                {
                    case ("Ellipse", "Area"):
                        result = new FigureBuilder(_mainWindowViewModel.EllipseViewModel).figureBase.Area;
                        break;

                    case ("Ellipse", "Perimeter"):
                        result = new FigureBuilder(_mainWindowViewModel.EllipseViewModel).figureBase.Perimeter;
                        break;

                    case ("Rectangle", "Area"):
                        result = new FigureBuilder(_mainWindowViewModel.RectangleViewModel).figureBase.Area;
                        break;

                    case ("Rectangle", "Perimeter"):
                        result = new FigureBuilder(_mainWindowViewModel.RectangleViewModel).figureBase.Perimeter;
                        break;

                    case ("Trapezoid", "Area"):
                        result = new FigureBuilder(_mainWindowViewModel.TrapezoidViewModel).figureBase.Area;
                        break;

                    case ("Trapezoid", "Perimeter"):
                        result = new FigureBuilder(_mainWindowViewModel.TrapezoidViewModel).figureBase.Perimeter;
                        break;

                    case ("Triangle", "Area"):
                        result = new FigureBuilder(_mainWindowViewModel.TriangleViewModel).figureBase.Area;
                        break;

                    case ("Triangle", "Perimeter"):
                        result = new FigureBuilder(_mainWindowViewModel.TriangleViewModel).figureBase.Perimeter;
                        break;
                }

                if (_mainWindowViewModel.FormulaType == "Area")
                {
                    if (_mainWindowViewModel.FigureType == "Ellipse")
                    {
                        result = new FigureBuilder(_mainWindowViewModel.EllipseViewModel).figureBase.Area;
                    }

                    if (_mainWindowViewModel.FigureType == "Rectangle")
                    {
                        result = new FigureBuilder(_mainWindowViewModel.RectangleViewModel).figureBase.Area;
                    }

                    if (_mainWindowViewModel.FigureType == "Trapezoid")
                    {
                        result = new FigureBuilder(_mainWindowViewModel.TrapezoidViewModel).figureBase.Area;
                    }

                    if (_mainWindowViewModel.FigureType == "Triangle")
                    {
                        result = new FigureBuilder(_mainWindowViewModel.TriangleViewModel).figureBase.Area;
                    }
                }

                _mainWindowViewModel.Result = $"Result {result}";
            }
            catch (Exception)
            {
                _mainWindowViewModel.ErrorMessage = "Something wrong! Check all fields, please!";
            }
        }
    }
}
