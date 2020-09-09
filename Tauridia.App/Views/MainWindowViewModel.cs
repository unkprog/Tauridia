using System.Runtime.Serialization;
using ReactiveUI;
using Tauridia.Core.Models;

namespace Tauridia.App.Views
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static MainWindowViewModel _this = null;
        public static MainWindowViewModel This
        {
            get { if (_this == null) _this = new MainWindowViewModel(); return _this; }
            private set { _this = value; }
        }

        public MainWindowViewModel()
        {
            _this = this;
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
