using System.Runtime.Serialization;
using ReactiveUI;
using Tauridia.App.ViewModels;

namespace Tauridia.App.Views
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel This;
        public MainWindowViewModel()
        {
            This = this;
            CurrentContent = new WelcomeViewModel();
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
