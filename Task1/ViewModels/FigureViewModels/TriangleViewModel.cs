using System;
using System.ComponentModel;

namespace Task1
{
    public class TriangleViewModel : ViewModelBase, IDataErrorInfo, IBuilder
    {
        public double _sideA;
        public double SideA
        {
            get
            {
                return _sideA;
            }
            set
            {
                _sideA = value;
                OnPropertyChanged();
            }
        }

        public double _baseB;
        public double BaseB
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

        public double _sideC;
        public double SideC
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

        public double _heightToB;
        public double HeightToB
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

        public ICalculator GetFigure()
        {
            Triangle triangle = new Triangle
            {
                A = SideA,
                B = BaseB,
                C = SideC,
                H = HeightToB
            };

            return triangle;
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                string errorMessage;

                if (!GetFigureValidator().Errors.ContainsKey(propertyName))
                {
                    errorMessage = null;
                }
                else
                {
                    errorMessage = String.Join(Environment.NewLine, GetFigureValidator().Errors[propertyName]);
                }

                CheckParams(GetFigureValidator());

                return errorMessage;
            }
        }

        private void CheckParams(IFigureValidator figureValidator)
        {
            CanGetArea = CanGetPerimeter = false;
            GeneralWarning = null;

            if (figureValidator.Errors.Count == 0
                && figureValidator.IsParamsValid(null, BaseB, HeightToB))
            {
                try
                {
                    CanGetArea = true;
                }
                catch (Exception e)
                {
                    GeneralWarning = e.Message;
                }
            }

            if (figureValidator.Errors.Count == 0
                && figureValidator.IsParamsValid(null, SideA, BaseB, SideC))
            {
                try
                {
                    CanGetPerimeter = figureValidator.IsPolygonExist(SideA, BaseB, SideC);
                }
                catch (Exception e)
                {
                    GeneralWarning = e.Message;
                }
            }
        }
    }
}
