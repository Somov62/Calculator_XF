using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator_XF.MVVM.Core
{
    internal class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Set<T>(ref T source, T value, string propertyName = null)
        {
            source = value;
            OnPropertyChanged(propertyName);
        }

        public void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
