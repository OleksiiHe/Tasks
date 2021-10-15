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

        public ICalculator GetFigure(FigureValidator validator)
        {
            if (validator.IsParamsValid(BaseA, BaseB, HeightToB)
                || (validator.IsParamsValid(BaseA, BaseB, SideC, SideD)
                && validator.IsPolygonExist(BaseA, BaseB, SideC, SideD)))
            {
                Trapezoid trapezoid = new Trapezoid
                {
                    A = BaseA,
                    B = BaseB,
                    C = SideC,
                    D = SideD,
                    H = HeightToB
                };

                return trapezoid;
            }

            else
            {
                throw new NullReferenceException(message: ValidationData.GENERAL_WARNING);
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {

            get
            {
                string result = null;
                FigureValidator figureValidator = new();

                if (name is nameof(BaseA)
                    or nameof(BaseB)
                    or nameof(SideC)
                    or nameof(SideD)
                    or nameof(HeightToB))
                {
                    if (!figureValidator.IsEmpty(BaseA, BaseB, SideC, SideD, HeightToB)
                        && figureValidator.IsOutOfRange(BaseA, BaseB, SideC, SideD, HeightToB))
                    {
                        result = ValidationData.VALUE_IS_OUT_OF_RANGE;
                    }

                    if (!figureValidator.IsEmpty(BaseA, BaseB, SideC, SideD)
                        && !figureValidator.IsPolygonExist(BaseA, BaseB, SideC, SideD))
                    {
                        result = ValidationData.POLYGON_IS_NOT_EXIST;
                    }
                }

                return result;
            }
        }
    }
}
