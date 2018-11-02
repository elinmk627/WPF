using System.ComponentModel;

namespace MvvmExam.ViewModel {
    class ViewModelBase : INotifyPropertyChanged  {
        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged(string pname) {
            PropertyChanged?.Invoke(this, new
           PropertyChangedEventArgs(pname));
        }
    }
}
