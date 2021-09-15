using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class FigureValidator //TODO: Simplify return. Create ValidationRules.
    {
        public bool IsEmpty(params double?[] args)
        {
            if (args.Length == 0)
            {
                return true;
            }

            return args.Any(p => string.IsNullOrEmpty(p.ToString()));
        }

        public bool IsOutOfRange(params double?[] args)
        {

            return args.Any(p => p is < ValidationData.MINVALUE or > ValidationData.MAXVALUE);
        }
        public bool IsPolygonExist(double? side1, double? side2, double? side3, double? side4 = 0)
        {
            if (!IsEmpty(side1, side2, side3, side4))
            {
                if (side1 < (side2 + side3 + side4)
                    && side2 < (side1 + side3 + side4)
                    && side3 < (side1 + side2 + side4)
                    && side4 < (side1 + side2 + side3))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
