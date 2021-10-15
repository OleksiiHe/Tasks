using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class MainWindowViewModel : ViewModelBase
    {
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
        public string AreaMessage
        {
            get
            {
                _result = Math.Round((double)new FigureBuilder(GetFigureModel()).figureBase.GetArea(), 5);
                return $"Area: {_result}";
            }
        }
        public string PerimeterMessage
        {
            get
            {
                 _result = Math.Round((double)new FigureBuilder(GetFigureModel()).figureBase.GetPerimeter(), 5);
                return $"Perimeter: {_result}";
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
                var name = typeof(MainWindowViewModel).Assembly.GetName().Name;
                _viewModelPath = $"{name}.{Enum.GetName(typeof(Figures), FigureType)}ViewModel";
                FigureViewModel = Activator.CreateInstance(name, _viewModelPath).Unwrap();

                ButtonVisibility = "Visible";
            }
        }
    }
}
