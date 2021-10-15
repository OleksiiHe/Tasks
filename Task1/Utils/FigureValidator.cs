using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class FigureValidator //TODO: Create ValidationRules.
    {
        public bool IsParamsValid (params double[] args)
        {
            return !IsEmpty(args) && !IsOutOfRange(args);
        }

        public bool IsEmpty(params double[] args)
        {
            return args.Any(p => string.IsNullOrEmpty(p.ToString()) || p <= 0);
        }

        public bool IsOutOfRange(params double[] args)
        {

            return args.Any(p => p is < ValidationData.MIN_VALUE or > ValidationData.MAX_VALUE);
        }

        public bool IsPolygonExist(double side1, double side2, double side3, double side4 = 0)
        {
            return side1 < (side2 + side3 + side4)
                    && side2 < (side1 + side3 + side4)
                    && side3 < (side1 + side2 + side4)
                    && side4 < (side1 + side2 + side3);
        }
    }
}
