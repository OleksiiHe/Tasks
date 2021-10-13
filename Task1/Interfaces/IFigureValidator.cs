using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IFigureValidator
    {
        public Dictionary<String, List<String>> Errors { get; set; }

        public bool IsParamsValid(string propertyName, params double[] args);
        public bool IsNotEmpty(string propertyName, params double[] args);
        public bool IsWithinTheRange(string propertyName, params double[] args);
        public bool IsParamsRatioCorrect(string greaterPropertyName, string lesserPropertyName, double greaterProperty, double lesserProperty);
        public bool IsPolygonExist(double side1, double side2, double side3, double side4 = 0);
    }
}
