using System;
using System.ComponentModel;

namespace Task1
{
    public class RectangleViewModel : ViewModelBase, IDataErrorInfo, IBuilder
    {
        private double _lengthL;
        public double LengthL
        {
            get
            {
                return _lengthL;
            }
            set
            {
                _lengthL = value;
                OnPropertyChanged();
            }
        }

        private double _widthW;
        public double WidthW

        {
            get
            {
                return _widthW;
            }
            set
            {
                _widthW = value;
                OnPropertyChanged();
            }
        }

        public ICalculator GetFigure(FigureValidator validator)
        {
            if (validator.IsParamsValid(WidthW, LengthL))
            {
                Rectangle rectangle = new Rectangle
                {
                    L = LengthL,
                    W = WidthW,
                };

                return rectangle;
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

                if (name is nameof(LengthL) or nameof(WidthW))
                {
                    if (figureValidator.IsOutOfRange(_lengthL, _widthW))
                    {
                        result = ValidationData.VALUE_IS_OUT_OF_RANGE;
                    }

                    //Formal. Not necessary
                    if (_lengthL < _widthW)
                    {
                        result = ValidationData.INCORRECT_SIDE;
                    }
                }

                return result;
            }
        }
    }
}
