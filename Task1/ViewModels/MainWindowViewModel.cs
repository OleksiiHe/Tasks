using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class MainWindowViewModel : ViewModelBase //TODO: Move Styles from App to Dictionary
    {
        private EllipseViewModel _ellipseViewModel;
        public EllipseViewModel EllipseViewModel
        {
            get
            {
                return _ellipseViewModel;
            }
            set
            {
                _ellipseViewModel = value;
                OnPropertyChanged();
            }
        }

        private RectangleViewModel _rectangleViewModel;
        public RectangleViewModel RectangleViewModel
        {
            get
            {
                return _rectangleViewModel;
            }
            set
            {
                _rectangleViewModel = value;
                OnPropertyChanged();
            }
        }

        private TrapezoidViewModel _trapezoidViewModel;
        public TrapezoidViewModel TrapezoidViewModel
        {
            get
            {
                return _trapezoidViewModel;
            }
            set
            {
                _trapezoidViewModel = value;
                OnPropertyChanged();
            }
        }

        private TriangleViewModel _triangleViewModel;
        public TriangleViewModel TriangleViewModel
        {
            get
            {
                return _triangleViewModel;
            }
            set
            {
                _triangleViewModel = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> FigureTypes //TODO: Remove Casting
        {
            get
            {
                return Enum.GetNames(typeof(Figures)).Cast<string>();
            }
        }

        private string _figureType = "";
        public string FigureType
        {
            get
            {
                return _figureType;
            }
            set
            {
                _figureType = value;
                OnPropertyChanged();
                Result = 0;
                ResultMessage = "";
                ErrorMessage = "";
            }
        }

        public IEnumerable<string> FormulaTypes //TODO: Remove Casting
        {
            get
            {
                return Enum.GetNames(typeof(Formulas)).Cast<string>();
            }
        }

        private string _formulaType = "";
        public string FormulaType
        {
            get
            {
                return _formulaType;
            }
            set
            {
                _formulaType = value;
                OnPropertyChanged();
                Result = 0;
                ResultMessage = "";
                ErrorMessage = "";
            }
        }

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private double? _result;
        public double? Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                ResultMessage = $"Result: {Result}";
                OnPropertyChanged();
            }
        }

        private string _resultMessage;
        public string ResultMessage
        {
            get
            {
                return _resultMessage;
            }
            set
            {
                _resultMessage = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _calculateCommand;
        public RelayCommand CalculateCommand
        {
            get
            {
                return _calculateCommand ??= new RelayCommand(obj =>
                  {
                      if (FormulaType == "Area")
                      {
                          Result = new FigureBuilder(GetFigureModel()).figureBase.GetArea();
                      }
                      if (FormulaType == "Perimeter")
                      {
                          Result = new FigureBuilder(GetFigureModel()).figureBase.GetPerimeter();
                      }
                  });
            }
        }

        public dynamic GetFigureModel() //TODO: Add Default
        {
            switch(FigureType)
            {
                case "Ellipse":
                    return EllipseViewModel;
                case "Rectangle":
                    return RectangleViewModel;
                case "Trapezoid":
                    return TrapezoidViewModel;
                case "Triangle":
                    return TriangleViewModel;
            }

            return null;
        }

        public MainWindowViewModel()
        {
            _ellipseViewModel = new EllipseViewModel();
            _rectangleViewModel = new RectangleViewModel();
            _trapezoidViewModel = new TrapezoidViewModel();
            _triangleViewModel = new TriangleViewModel();
        }
    }
}
