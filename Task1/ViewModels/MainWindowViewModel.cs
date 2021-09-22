using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const string _ASSAMBLYNAME = "Task1";
        private string _viewModelPath;

        private string _formulaType;
        private double? _result;

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

        private Figures _figureType;
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

                _result = 0;
                AreaMessage = "";
                PerimeterMessage = "";
                ErrorMessage = "";
            }
        }

        //public string FormulaType
        //{
        //    get
        //    {
        //        return _formulaType;
        //    }
        //    set
        //    {
        //        _formulaType = value;
        //        OnPropertyChanged();
        //    }
        //}

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

        //public double? Result
        //{
        //    get
        //    {
        //        return _result;
        //    }
        //    set
        //    {
        //        _result = value;
        //        OnPropertyChanged();
        //    }
        //}

        private string _areaMessage;
        public string AreaMessage
        {
            get
            {
                return _areaMessage;
            }
            set
            {
                _areaMessage = value;
                OnPropertyChanged();
            }
        }

        private string _perimeterMessage;
        public string PerimeterMessage
        {
            get
            {
                return _perimeterMessage;
            }
            set
            {
                _perimeterMessage = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _getAreaCommand;
        public RelayCommand GetAreaCommand
        {
            get
            {
                return _getAreaCommand ??= new RelayCommand(obj =>
                  {
                      _formulaType = Enum.GetName(typeof(Formulas), Formulas.Area);
                      _result = Math.Round((double)new FigureBuilder(GetFigureModel()).figureBase.GetArea(), 5);
                      AreaMessage = $"{_formulaType}: {_result}";
                  });
            }
        }

        private RelayCommand _getPerimeterCommand;
        public RelayCommand GetPerimeterCommand
        {
            get
            {
                return _getPerimeterCommand ??= new RelayCommand(obj =>
                {
                    _formulaType = Enum.GetName(typeof(Formulas), Formulas.Perimeter);
                    _result = Math.Round((double)new FigureBuilder(GetFigureModel()).figureBase.GetPerimeter(), 5);
                    PerimeterMessage = $"{_formulaType}: {_result}";
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
