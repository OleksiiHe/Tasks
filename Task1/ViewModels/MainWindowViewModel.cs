using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const string _ASSAMBLY_NAME = "Task1";
        private string _viewModelPath;
        private string _formulaType;

        private IFigureValidator _validator;
        public IFigureValidator Validator
        {
            get
            {
                return GetFigureValidator();
            }
            set
            {
                _validator = value;
                OnPropertyChanged();
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
                      try
                      {
                          _formulaType = Enum.GetName(typeof(Formulas), Formulas.Area);
                          var result = (FigureViewModel as IBuilder).GetFigure().GetArea();
                          AreaMessage = $"{_formulaType}: {RoundResult(result)}";
                      }

                      catch (Exception e)
                      {
                          GeneralWarning = e.Message;
                      }
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
                    try
                    {
                        _formulaType = Enum.GetName(typeof(Formulas), Formulas.Perimeter);
                        var result = (FigureViewModel as IBuilder).GetFigure().GetPerimeter();
                        PerimeterMessage = $"{_formulaType}: {RoundResult(result)}";
                    }

                    catch (Exception e)
                    {
                        GeneralWarning = e.Message;
                    }
                });
            }
        }

        private void SetFigure()
        {
            if (FigureType > 0)
            {
                _viewModelPath = $"{_ASSAMBLY_NAME}.{Enum.GetName(typeof(Figures), FigureType)}ViewModel";
                FigureViewModel = Activator.CreateInstance(_ASSAMBLY_NAME, _viewModelPath).Unwrap();

                ButtonVisibility = "Visible";

                AreaMessage = "";
                PerimeterMessage = "";
            }
        }

        private double RoundResult(double result)
        {
            return Math.Round((double)result, 5);
        }
    }
}
