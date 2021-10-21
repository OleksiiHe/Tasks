using System;
using System.ComponentModel;

namespace Task1
{
    public class EllipseViewModel : ViewModelBase, IDataErrorInfo, IBuilder
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

        private double _minorRadiusB;
        public double MinorRadiusB
        {
            get
            {
                return _minorRadiusB;
            }
            set
            {
                _minorRadiusB = value;
                OnPropertyChanged();
            }
        }

        public ICalculator GetFigure()
        {
            Ellipse ellipse = new()
            {
                A = MajorRadiusA,
                B = MinorRadiusB,
            };

            return ellipse;
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string propertyName]
        {
            get
            {
                string errorMessage;

                if (!FigureValidator.Errors.ContainsKey(propertyName))
                {
                    errorMessage = null;
                }
                else
                {
                    errorMessage = String.Join(Environment.NewLine, FigureValidator.Errors[propertyName]);
                }

                CheckParams();

                return errorMessage;
            }
        }

        private void CheckParams()
        {
            CanGetArea = CanGetPerimeter = false;
            GeneralWarning = null;

            if (FigureValidator.Errors.Count == 0
                && FigureValidator.IsParamsValid(null, MajorRadiusA, MinorRadiusB))
            {
                try
                {
                    CanGetArea = CanGetPerimeter = FigureValidator.IsParamsRatioCorrect(nameof(MajorRadiusA), nameof(MinorRadiusB), MajorRadiusA, MinorRadiusB);
                }
                catch (Exception e)
                {
                    GeneralWarning = e.Message;
                }
            }
        }
    }
}
