using System.ComponentModel;

namespace Task1
{
    public class TriangleViewModel : ViewModelBase, IDataErrorInfo
    {
        public double? _sideA;
        public double? SideA
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

        public double? _baseB;
        public double? BaseB
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

        public double? _sideC;
        public double? SideC
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

        public double? _heightToB;
        public double? HeightToB
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
                    if (figureValidator.IsOutOfRange(SideA, BaseB, SideC, HeightToB))
                    {
                        result = ValidationData.VALUEISOUTOFRANGE;
                    }

                    if (!figureValidator.IsPolygonExist(SideA, BaseB, SideC))
                    {
                        result = ValidationData.POLYGONISNOTEXIST;
                    }
                }

                return result;
            }
        }
    }
}
