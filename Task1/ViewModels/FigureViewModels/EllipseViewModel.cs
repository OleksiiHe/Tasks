namespace Task1
{
    public class EllipseViewModel : ViewModelBase
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

        private double _minorRadiusA;
        public double MinorRadiusB
        {
            get
            {
                return _minorRadiusA;
            }
            set
            {
                _minorRadiusA = value;
                OnPropertyChanged();
            }
        }

        //private double _area;
        //public double Area
        //{
        //    get
        //    {
        //        return _area;
        //    }
        //    set
        //    {
        //        _area = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private double _perimeter;
        //public double Perimeter
        //{
        //    get
        //    {
        //        return _perimeter;
        //    }
        //    set
        //    {
        //        _perimeter = value;
        //        OnPropertyChanged();
        //    }
        //}
    }
}
