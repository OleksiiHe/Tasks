using System;
using System.ComponentModel;

namespace Task1
{
    public class EllipseViewModel : ViewModelBase, IDataErrorInfo, IBuilder
    {
        private double _majorRadiusA;
        public double MajorRadiusA
        {
            get
            {
                return _majorRadiusA;
            }
            set
            {
                _majorRadiusA = value;
                OnPropertyChanged();
            }
        }

        private double _minorRadiusB;
        public double MinorRadiusB
        {
            get
            {
                return _minorRadiusB;
            }
            set
            {
                _minorRadiusB = value;
                OnPropertyChanged();
            }
        }

        public ICalculator GetFigure(FigureValidator validator)
        {
            if (validator.IsParamsValid(MajorRadiusA, MinorRadiusB))
            {
                Ellipse ellipse = new()
                {
                    A = MajorRadiusA,
                    B = MinorRadiusB,
                };

                return ellipse;
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

                if (name is nameof(MajorRadiusA) or nameof(MinorRadiusB))
                {
                    if (figureValidator.IsOutOfRange(_majorRadiusA, _minorRadiusB))
                    {
                        result = ValidationData.VALUE_IS_OUT_OF_RANGE;
                    }

                    //Formal. Not necessary
                    if (_majorRadiusA < _minorRadiusB)
                    {
                        result = ValidationData.INCORRECT_RADIUS;
                    }
                }

                return result;
            }
        }
    }
}
