using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class TriangleViewModel : ViewModelBase
    {
        public double SideA { get; set; }
        public double BaseB { get; set; }
        public double SideC { get; set; }
        public double HeightToB { get; set; }

        //public double Area { get; set; }
        //public double Perimeter { get; set; }
    }
}
