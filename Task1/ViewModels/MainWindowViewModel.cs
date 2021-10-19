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
                double result = 0;

                if (FigureViewModel != null)
                {
                    result = RoundResult((FigureViewModel as IBuilder).GetFigure().GetArea());
                }

                if (result > 0)
                {
                    return $"Area: {result}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string PerimeterMessage
        {
            get
            {
                double result = 0;

                if (FigureViewModel != null)
                {
                    result = RoundResult((FigureViewModel as IBuilder).GetFigure().GetPerimeter());
                }

                if (result > 0)
                {
                    return $"Perimeter: {result}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private RelayCommand _getAreaCommand;

        public RelayCommand GetAreaCommand
        {
            get
            {
                return _getAreaCommand ??= new RelayCommand(obj =>
                             {
                                 OnPropertyChanged(nameof(AreaMessage));
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
                                 OnPropertyChanged(nameof(PerimeterMessage));
                             });
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

                OnPropertyChanged(nameof(AreaMessage));
                OnPropertyChanged(nameof(PerimeterMessage));
            }
        }

        private double RoundResult(double result)
        {
            return Math.Round((double)result, 5);
        }
    }
}
