namespace Task1
{
    public class TrapezoidViewModel : ViewModelBase //TODO: IS OnPropertyChanged needed?
    {
        public double BaseA { get; set; }
        public double BaseB { get; set; }
        public double SideC { get; set; }
        public double SideD { get; set; }
        public double HeightToB { get; set; }

        //public double Area { get; set; }
        //public double Perimeter { get; set; }
    }
}
