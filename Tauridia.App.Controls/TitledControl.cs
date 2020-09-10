using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Metadata;


namespace Tauridia.App.Controls
{
    public partial class TitledControl : TemplatedControl, IContentControl, IContentPresenterHost
    {
        public static readonly StyledProperty<object> ContentProperty =
            AvaloniaProperty.Register<TitledControl, object>(nameof(Content));

        public static readonly StyledProperty<IDataTemplate> ContentTemplateProperty =
            AvaloniaProperty.Register<TitledControl, IDataTemplate>(nameof(ContentTemplate));

        public static readonly StyledProperty<HorizontalAlignment> HorizontalContentAlignmentProperty =
           AvaloniaProperty.Register<TitledControl, HorizontalAlignment>(nameof(HorizontalContentAlignment));

        public static readonly StyledProperty<VerticalAlignment> VerticalContentAlignmentProperty =
           AvaloniaProperty.Register<TitledControl, VerticalAlignment>(nameof(VerticalContentAlignment));

        static TitledControl()
        {
            ContentProperty.Changed.AddClassHandler<TitledControl>((x, e) => x.ContentChanged(e));
        }

        [Content]
        [DependsOn(nameof(ContentTemplate))]
        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public IDataTemplate ContentTemplate
        {
            get { return GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        public IContentPresenter Presenter
        {
            get;
            private set;
        }

        public HorizontalAlignment HorizontalContentAlignment
        {
            get { return GetValue(HorizontalContentAlignmentProperty); }
            set { SetValue(HorizontalContentAlignmentProperty, value); }
        }

        public VerticalAlignment VerticalContentAlignment
        {
            get { return GetValue(VerticalContentAlignmentProperty); }
            set { SetValue(VerticalContentAlignmentProperty, value); }
        }

        IAvaloniaList<ILogical> IContentPresenterHost.LogicalChildren => LogicalChildren;

        bool IContentPresenterHost.RegisterContentPresenter(IContentPresenter presenter)
        {
            return RegisterContentPresenter(presenter);
        }

        protected virtual bool RegisterContentPresenter(IContentPresenter presenter)
        {
            if (presenter.Name == "PART_ContentPresenter")
            {
                Presenter = presenter;
                return true;
            }

            return false;
        }

        private void ContentChanged(AvaloniaPropertyChangedEventArgs e)
        {
            if (e.OldValue is ILogical oldChild)
            {
                LogicalChildren.Remove(oldChild);
            }

            if (e.NewValue is ILogical newChild)
            {
                LogicalChildren.Add(newChild);
            }
        }
    }
}
