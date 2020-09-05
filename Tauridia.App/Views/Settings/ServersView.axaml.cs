using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Tauridia.App.Models.Settings;

namespace Tauridia.App.Views.Settings
{

    public class ServersView : UserControl
    {
        public ServersView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            //_viewModel = this.DataContext as ServersViewModel;
            //_repeater = this.FindControl<ItemsRepeater>("irListServers");
            //_repeater.PointerPressed += RepeaterClick;
        }
        //private ItemsRepeater _repeater;
        //private ServersViewModel _viewModel;
        //private void RepeaterClick(object sender, PointerPressedEventArgs e)
        //{
        //    var item = (e.Source as TextBlock)?.DataContext as ServerModel;
        //    (this.DataContext as ServersViewModel).SelectedServer = item;
        //}
    }
}
