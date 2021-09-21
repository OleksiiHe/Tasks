using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const string _ASSAMBLYNAME = "Task1";
        private string _viewModelPath;

        private object _figureViewModel;
        public object FigureViewModel
        {
            get
            {
                return _figureViewModel;
            }
            set
            {
                _figureViewModel = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Figures> FigureTypes
        {
            get
            {
                return (IEnumerable<Figures>)Enum.GetValues(typeof(Figures));
            }
        }

        private Figures _figureType = 0;
        public Figures FigureType
        {
            get
            {
                return _figureType;
            }
            set
            {
                _figureType = value;
                OnPropertyChanged();
                SetFigure();

                Result = 0;
                ResultMessage = "";
                ErrorMessage = "";
            }
        }

        public IEnumerable<string> FormulaTypes //TODO: Extract to two different buttons
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

        private string _buttonVisibility = "Collapsed";
        public string ButtonVisibility
        {
            get
            {
                return _buttonVisibility;
            }
            set
            {
                _buttonVisibility = value;
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

        public dynamic GetFigureModel()
        {
            switch(FigureType)
            {
                case Figures.Ellipse:
                    return FigureViewModel as EllipseViewModel;
                case Figures.Rectangle:
                    return FigureViewModel as RectangleViewModel;
                case Figures.Trapezoid:
                    return FigureViewModel as TrapezoidViewModel;
                case Figures.Triangle:
                    return FigureViewModel as TriangleViewModel;
                default:
                    return null;
            }
        }

        public MainWindowViewModel()
        {
        }

        private void SetFigure()
        {
            if (FigureType > 0)
            {
                _viewModelPath = $"{_ASSAMBLYNAME}.{Enum.GetName(typeof(Figures), FigureType)}ViewModel";
                FigureViewModel = Activator.CreateInstance(_ASSAMBLYNAME, _viewModelPath).Unwrap();

                ButtonVisibility = "Visible";
            }
        }
    }
}
