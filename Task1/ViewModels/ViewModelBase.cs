using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task1
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool _canGetArea;
        public bool CanGetArea
        {
            get
            {
                return _canGetArea;
            }
            set
            {
                _canGetArea = value;
                OnPropertyChanged();
            }
        }

        private bool _canGetPerimeter;
        public bool CanGetPerimeter
        {
            get
            {
                return _canGetPerimeter;
            }
            set
            {
                _canGetPerimeter = value;
                OnPropertyChanged();
            }
        }

        private string _generalWarning;

        public string GeneralWarning
        {
            get
            {
                return _generalWarning;
            }
            set
            {
                _generalWarning = value;
                OnPropertyChanged();
            }
        }

        private readonly IFigureValidator _figureValidator = new FigureValidator();
        protected IFigureValidator GetFigureValidator()
        {
            return _figureValidator;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (name != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
