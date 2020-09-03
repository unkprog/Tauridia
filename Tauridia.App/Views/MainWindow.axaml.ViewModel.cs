using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.App.ViewModels.MainWindow
{
    public class ViewModel : ViewModelBase
    {
        public static ViewModel This;
        public ViewModel()
        {
            This = this;
            CurrentContent = new Welcome.ViewModel();
        }

        private ViewModelBase _currentContent;

        [DataMember]
        public ViewModelBase CurrentContent
        {
            get => _currentContent;
            set => this.RaiseAndSetIfChanged(ref _currentContent, value);
        }


    }

}
