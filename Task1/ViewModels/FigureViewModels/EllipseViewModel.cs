using System.ComponentModel;

namespace Task1
{
    public class EllipseViewModel : ViewModelBase, IDataErrorInfo
    {
        private double? _majorRadiusA;
        public double? MajorRadiusA
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

        private double? _minorRadiusB;
        public double? MinorRadiusB
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
                        result = ValidationData.VALUEISOUTOFRANGE;
                    }

                    //Formal. Not necessary
                    if (_majorRadiusA < _minorRadiusB)
                    {
                        result = ValidationData.INCORRECTRADIUS;
                    }
                }

                return result;
            }
        }
    }
}
