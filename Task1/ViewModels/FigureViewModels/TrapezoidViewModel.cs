using System;
using System.ComponentModel;

namespace Task1
{
    public class TrapezoidViewModel : ViewModelBase, IDataErrorInfo, IBuilder
    {
        private double _baseA;
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

        private double _baseB;
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

        private double _sideC;
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

        private double _sideD;
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

        private double _heightToB;
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
            Trapezoid trapezoid = new ()
            {
                A = BaseA,
                B = BaseB,
                C = SideC,
                D = SideD,
                H = HeightToB,
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

                if (!GetFigureValidator().Errors.ContainsKey(propertyName))
                {
                    errorMessage = null;
                }
                else
                {
                    errorMessage = string.Join(Environment.NewLine, GetFigureValidator().Errors[propertyName]);
                }

                CheckParams(GetFigureValidator());

                return errorMessage;
            }
        }

        private void CheckParams(IFigureValidator figureValidator)
        {
            CanGetArea = CanGetPerimeter = false;
            GeneralWarning = null;

            if (figureValidator.Errors.Count == 0
                && figureValidator.IsParamsValid(null, BaseA, BaseB, HeightToB))
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

            if (figureValidator.Errors.Count == 0
                && figureValidator.IsParamsValid(null, BaseA, BaseB, SideC, SideD))
            {
                try
                {
                    CanGetPerimeter = figureValidator.IsPolygonExist(BaseA, BaseB, SideC, SideD);
                }
                catch (Exception e)
                {
                    GeneralWarning = e.Message;
                }
            }
        }
    }
}
