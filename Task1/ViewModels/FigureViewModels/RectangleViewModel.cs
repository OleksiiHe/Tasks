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

        public ICalculator GetFigure()
        {
            Rectangle rectangle = new ()
            {
                L = LengthL,
                W = WidthW,
            };

            return rectangle;
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
                && figureValidator.IsParamsValid(null, LengthL, WidthW))
            {
                try
                {
                    CanGetArea = CanGetPerimeter = figureValidator.IsParamsRatioCorrect(
                        nameof(LengthL), nameof(WidthW), LengthL, WidthW);
                }
                catch (Exception e)
                {
                    GeneralWarning = e.Message;
                }
            }
        }
    }
}
