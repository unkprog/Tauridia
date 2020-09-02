using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.App.ViewModels.MainWindow
{
    public class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            CurrentContent = new ViewModels.WelcomeSreen.ViewModel();
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
