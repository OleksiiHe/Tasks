namespace Task1
{
    public class RectangleViewModel : ViewModelBase
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
