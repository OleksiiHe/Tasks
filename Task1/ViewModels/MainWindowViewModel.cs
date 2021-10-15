using System;
using System.Collections.Generic;

namespace Task1
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _viewModelPath;

        public IFigureValidator Validator
        {
            get
            {
                return GetFigureValidator();
            }
        }

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

        public static IEnumerable<Figures> FigureTypes
        {
            get
            {
                return (IEnumerable<Figures>)Enum.GetValues(typeof(Figures));
            }
        }

        private Figures _figureType;
        public Figures FigureType
        {
            get => _figureType;
            set
            {
                _figureType = value;
                OnPropertyChanged();

                SetFigure();
            }
        }

        private string _errorMessage;
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
                var _result = RoundResult((FigureViewModel as IBuilder).GetFigure().GetArea());
                return $"Area: {_result}";
            }
        }
        public string PerimeterMessage
        {
            get 
            { 
                var _result = RoundResult((FigureViewModel as IBuilder).GetFigure().GetPerimeter());
                return $"Perimeter: {_result}";
            }
        }

        private void SetFigure()
        {
            if (FigureType > 0)
            { 
                var name = typeof(MainWindowViewModel).Assembly.GetName().Name;
                _viewModelPath = $"{name}.{Enum.GetName(typeof(Figures), FigureType)}ViewModel";
                FigureViewModel = Activator.CreateInstance(name, _viewModelPath).Unwrap();

                ButtonVisibility = "Visible";
                ErrorMessage = "";
                ErrorMessage = "";
            }
        }

        private double RoundResult(double result)
        {
            return Math.Round((double)result, 5);
        }
    }
}
