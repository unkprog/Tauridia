using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Tauridia.App.Views.Project
{
    public class NewProjectView : UserControl
    {
        public NewProjectView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
