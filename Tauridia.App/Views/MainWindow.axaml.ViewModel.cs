using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.App.ViewModels.MainWindow
{
    public class ViewModel : ModelBase
    {
        public static ViewModel This;
        public ViewModel()
        {
            This = this;
            CurrentContent = new Welcome.ViewModel();
        }

        private ModelBase _currentContent;

        [DataMember]
        public ModelBase CurrentContent
        {
            get => _currentContent;
            set => this.RaiseAndSetIfChanged(ref _currentContent, value);
        }


    }

}
