using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Tauridia.App.Views
{
    public partial class TitledView : UserControl
    {
        public TitledView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.Content
        }

        public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<TitledView, string>(nameof(Title));
        public string Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly StyledProperty<bool> VisibleCheckProperty = AvaloniaProperty.Register<TitledView, bool>(nameof(VisibleCheck));
        public bool VisibleCheck
        {
            get { return GetValue(VisibleCheckProperty); }
            set { SetValue(VisibleCheckProperty, value); }
        }

        public static readonly StyledProperty<bool> VisibleCloseProperty = AvaloniaProperty.Register<TitledView, bool>(nameof(VisibleClose));
        public bool VisibleClose
        {
            get { return GetValue(VisibleCloseProperty); }
            set { SetValue(VisibleCloseProperty, value); }
        }


    }
}
