using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Task1
{
    class MainWindowViewModel : ViewModelBase
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

        public IEnumerable<string> FigureTypes
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
                Result = "";
            }
        }

        public IEnumerable<string> FormulaTypes
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
                Result = "";
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

        private string _result;
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateCommand { get; }

        public MainWindowViewModel()
        {
            _ellipseViewModel = new EllipseViewModel();
            _rectangleViewModel = new RectangleViewModel();
            _trapezoidViewModel = new TrapezoidViewModel();
            _triangleViewModel = new TriangleViewModel();

            CalculateCommand = new CalculateCommand(this);
        }
    }
}
