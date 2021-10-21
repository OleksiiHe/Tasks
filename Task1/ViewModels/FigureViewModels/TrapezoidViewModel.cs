using System;
using System.ComponentModel;

namespace Task1
{
    public class TrapezoidViewModel : ViewModelBase, IDataErrorInfo, IBuilder
    {
        public double _baseA;
        public double BaseA
        {
            get
            {
                return _baseA;
            }
            set
            {
                _baseA = value;
                OnPropertyChanged();
            }
        }

        public double _baseB;
        public double BaseB
        {
            get
            {
                return _baseB;
            }
            set
            {
                _baseB = value;
                OnPropertyChanged();
            }
        }

        public double _sideC;
        public double SideC
        {
            get
            {
                return _sideC;
            }
            set
            {
                _sideC = value;
                OnPropertyChanged();
            }
        }

        public double _sideD;
        public double SideD
        {
            get
            {
                return _sideD;
            }
            set
            {
                _sideD = value;
                OnPropertyChanged();
            }
        }

        public double _heightToB;
        public double HeightToB
        {
            get
            {
                return _heightToB;
            }
            set
            {
                _heightToB = value;
                OnPropertyChanged();
            }
        }

        public ICalculator GetFigure()
        {
            Trapezoid trapezoid = new()
            {
                A = BaseA,
                B = BaseB,
                C = SideC,
                D = SideD,
                H = HeightToB
            };

            return trapezoid;
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                string errorMessage;

                if (!FigureValidator.Errors.ContainsKey(propertyName))
                {
                    errorMessage = null;
                }
                else
                {
                    errorMessage = string.Join(Environment.NewLine, FigureValidator.Errors[propertyName]);
                }

                CheckParams();

                return errorMessage;
            }
        }

        private void CheckParams()
        {
            CanGetArea = CanGetPerimeter = false;
            GeneralWarning = null;

            if (FigureValidator.Errors.Count == 0
                && FigureValidator.IsParamsValid(null, BaseA, BaseB, HeightToB))
            {
                try
                {
                    CanGetArea = true;
                }
                catch (Exception e)
                {
                    GeneralWarning = e.Message;
                }
            }

            if (FigureValidator.Errors.Count == 0
                && FigureValidator.IsParamsValid(null, BaseA, BaseB, SideC, SideD))
            {
                try
                {
                    CanGetPerimeter = FigureValidator.IsPolygonExist(BaseA, BaseB, SideC, SideD);
                }
                catch (Exception e)
                {
                    GeneralWarning = e.Message;
                }
            }
        }
    }
}
