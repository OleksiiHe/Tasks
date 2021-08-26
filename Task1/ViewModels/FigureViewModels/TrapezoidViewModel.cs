using System.ComponentModel;

namespace Task1
{
    public class TrapezoidViewModel : ViewModelBase, IDataErrorInfo
    {
        public double? _baseA;
        public double? BaseA
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

        public double? _sideD;
        public double? SideD
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

                if (name is nameof(BaseA) 
                    or nameof(BaseB) 
                    or nameof(SideC) 
                    or nameof(SideD)
                    or nameof(HeightToB))
                {
                    if (figureValidator.IsOutOfRange(BaseA, BaseB, SideC, SideD, HeightToB))
                    {
                        result = ValidationData.VALUEISOUTOFRANGE;
                    }

                    if (!figureValidator.IsPolygonExist(BaseA, BaseB, SideC, SideD))
                    {
                        result = ValidationData.POLYGONISNOTEXIST;
                    }
                }

                return result;
            }
        }
    }
}
