using System;
using System.ComponentModel;

namespace Task1
{
    public class TriangleViewModel : ViewModelBase, IDataErrorInfo, IBuilder
    {
        public double _sideA;
        public double SideA
        {
            get
            {
                return _sideA;
            }
            set
            {
                _sideA = value;
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
            if (validator.IsParamsValid(BaseB, HeightToB)
                || (validator.IsParamsValid(SideA, BaseB, SideC)
                && validator.IsPolygonExist(SideA, BaseB, SideC)))
            {
                Triangle triangle = new Triangle
                {
                    A = SideA,
                    B = BaseB,
                    C = SideC,
                    H = HeightToB
                };

                return triangle;
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

                if (name is nameof(SideA)
                    or nameof(BaseB)
                    or nameof(SideC)
                    or nameof(HeightToB))
                {
                    if (!figureValidator.IsEmpty(SideA, BaseB, SideC, HeightToB)
                        && figureValidator.IsOutOfRange(SideA, BaseB, SideC, HeightToB))
                    {
                        result = ValidationData.VALUE_IS_OUT_OF_RANGE;
                    }

                    if (!figureValidator.IsEmpty(SideA, BaseB, SideC)
                        && !figureValidator.IsPolygonExist(SideA, BaseB, SideC))
                    {
                        result = ValidationData.POLYGON_IS_NOT_EXIST;
                    }
                }

                return result;
            }
        }
    }
}
