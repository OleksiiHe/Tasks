using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public static class FigureValidator
    {
        private static Dictionary<string, List<string>> _errors = new();

        public static Dictionary<string, List<string>> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
            }
        }

        private static void AddError(string error, string propertyName)
        {
            if (propertyName != null
                && !_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }

            if (propertyName != null
                && !_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Insert(0, error);
            }
        }

        private static void RemoveError(string error, string propertyName)
        {
            if (propertyName != null
                && _errors.ContainsKey(propertyName) 
                && _errors[propertyName].Contains(error))
            {
                _errors[propertyName].Remove(error);

                if (_errors[propertyName].Count == 0)
                {
                    _errors.Remove(propertyName);
                }
            }
        }

        public static bool IsParamsValid (string propertyName, params double[] args)
        {
            return IsNotEmpty(propertyName, args) && IsWithinTheRange(propertyName, args);
        }

        public static bool IsNotEmpty(string propertyName, params double[] args)
        {
            bool isNotEmpty = !args.Any(p => string.IsNullOrEmpty(p.ToString()));

            if (!isNotEmpty)
            {
                AddError(ValidationData.PARAM_IS_EMPTY 
                    + propertyName, propertyName);

                return isNotEmpty;
            }
            else
            {
                RemoveError(ValidationData.PARAM_IS_EMPTY 
                    + propertyName, propertyName);

                return isNotEmpty;
            }
        }

        public static bool IsWithinTheRange(string propertyName, params double[] args)
        {
            bool isWithinTheRange = args.All(p => p is > ValidationData.MIN_VALUE and <= ValidationData.MAX_VALUE);

            if (!isWithinTheRange)
            {
                AddError(ValidationData.VALUE_IS_OUT_OF_RANGE 
                    + ValidationData.MIN_VALUE + " - " 
                    + ValidationData.MAX_VALUE + ".", 
                    propertyName);

                return isWithinTheRange;
            }
            else
            {
                RemoveError(ValidationData.VALUE_IS_OUT_OF_RANGE 
                    + ValidationData.MIN_VALUE + " - " 
                    + ValidationData.MAX_VALUE + ".", 
                    propertyName);

                return isWithinTheRange;
            }
        }

        public static bool IsParamsRatioCorrect(string greaterPropertyName, string lesserPropertyName, double greaterProperty, double lesserProperty)
        {
            bool isParamsRatioCorrect = greaterProperty >= lesserProperty;

            if (!isParamsRatioCorrect)
            {
                throw new ArgumentException(greaterPropertyName 
                    + ValidationData.PARAMS_RATIO_IS_NOT_CORRECT 
                    + lesserPropertyName);
            }
            else
            {
                return isParamsRatioCorrect;
            }
        }

        public static bool IsPolygonExist(double side1, double side2, double side3, double side4 = 0)
        {
            bool isPolygonExist = side1 < (side2 + side3 + side4)
                                    && side2 < (side1 + side3 + side4)
                                    && side3 < (side1 + side2 + side4)
                                    && side4 < (side1 + side2 + side3);

            if (!isPolygonExist)
            {
                throw new ArgumentException(ValidationData.POLYGON_IS_NOT_EXIST);
            }
            else
            {
                return isPolygonExist;
            }
        }
    }
}
