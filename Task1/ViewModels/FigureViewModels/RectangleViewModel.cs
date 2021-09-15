using System.ComponentModel;

namespace Task1
{
    public class RectangleViewModel : ViewModelBase, IDataErrorInfo
    {
        private double? _lengthL;
        public double? LengthL
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

        private double? _widthW;
        public double? WidthW

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
                        result = ValidationData.VALUEISOUTOFRANGE;
                    }

                    //Formal. Not necessary
                    if (_lengthL < _widthW)
                    {
                        result = ValidationData.INCORRECTSIDE;
                    }
                }

                return result;
            }
        }
    }
}
