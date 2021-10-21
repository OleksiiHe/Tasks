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
            Rectangle rectangle = new Rectangle
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

                if (!FigureValidator.Errors.ContainsKey(propertyName))
                {
                    errorMessage = null;
                }
                else
                {
                    errorMessage = String.Join(Environment.NewLine, FigureValidator.Errors[propertyName]);
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
                && FigureValidator.IsParamsValid(null, LengthL, WidthW))
            {
                try
                {
                    CanGetArea = CanGetPerimeter = FigureValidator.IsParamsRatioCorrect(nameof(LengthL), 
                        nameof(WidthW), LengthL, WidthW);
                }
                catch (Exception e)
                {
                    GeneralWarning = e.Message;
                }
            }
        }
    }
}
