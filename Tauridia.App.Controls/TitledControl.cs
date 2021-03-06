﻿using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Metadata;
using System;
using System.Drawing;
using System.Windows.Input;

#nullable enable

namespace Tauridia.App.Controls
{
    public partial class TitledControl : TemplatedControl,  IHeadered, IContentControl, IContentPresenterHost
    {
        static TitledControl()
        {
            HeaderProperty.Changed.AddClassHandler<TitledControl>((x, e) => x.HeaderContentChanged(e));
            ContentProperty.Changed.AddClassHandler<TitledControl>((x, e) => x.HeaderContentChanged(e));
        }

        public static readonly StyledProperty<object?> HeaderProperty = AvaloniaProperty.Register<TitledControl, object?>(nameof(Header));
        public object? Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly StyledProperty<Avalonia.Media.IBrush?> HeaderBackgroundProperty = AvaloniaProperty.Register<TitledControl, Avalonia.Media.IBrush?>(nameof(HeaderBackground));
        
        public Avalonia.Media.IBrush? HeaderBackground
        {
            get => GetValue(HeaderBackgroundProperty);
            set => SetValue(HeaderBackgroundProperty, value);
        }

        public static readonly StyledProperty<IDataTemplate?> HeaderTemplateProperty = AvaloniaProperty.Register<TitledControl, IDataTemplate?>(nameof(HeaderTemplate));
        public IContentPresenter? HeaderPresenter
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the data template used to display the header content of the control.
        /// </summary>
        public IDataTemplate? HeaderTemplate
        {
            get => GetValue(HeaderTemplateProperty);
            set => SetValue(HeaderTemplateProperty, value);
        }

        public static readonly StyledProperty<object> ContentProperty = AvaloniaProperty.Register<TitledControl, object>(nameof(Content));
        [Content]
        [DependsOn(nameof(ContentTemplate))]
        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly StyledProperty<IDataTemplate> ContentTemplateProperty = AvaloniaProperty.Register<TitledControl, IDataTemplate>(nameof(ContentTemplate));
        public IDataTemplate ContentTemplate
        {
            get { return GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        public IContentPresenter? Presenter
        {
            get;
            private set;
        }

        public static readonly StyledProperty<HorizontalAlignment> HorizontalContentAlignmentProperty = AvaloniaProperty.Register<TitledControl, HorizontalAlignment>(nameof(HorizontalContentAlignment));
        public HorizontalAlignment HorizontalContentAlignment
        {
            get { return GetValue(HorizontalContentAlignmentProperty); }
            set { SetValue(HorizontalContentAlignmentProperty, value); }
        }

        public static readonly StyledProperty<VerticalAlignment> VerticalContentAlignmentProperty = AvaloniaProperty.Register<TitledControl, VerticalAlignment>(nameof(VerticalContentAlignment));
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
            if (presenter.Name == "PART_HeaderPresenter")
            {
                HeaderPresenter = presenter;
                return true;
            }
            if (presenter.Name == "PART_ContentPresenter")
            {
                Presenter = presenter;
                return true;
            }
            return false;
        }

        private void HeaderContentChanged(AvaloniaPropertyChangedEventArgs e)
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

        public static readonly StyledProperty<bool> IsVisibleOkProperty = AvaloniaProperty.Register<TitledControl, bool>(nameof(IsVisibleOk));
        public bool IsVisibleOk
        {
            get { return GetValue(IsVisibleOkProperty); }
            set { SetValue(IsVisibleOkProperty, value); }
        }

        public static readonly StyledProperty<bool> IsVisibleCancelProperty = AvaloniaProperty.Register<TitledControl, bool>(nameof(IsVisibleCancel));
        public bool IsVisibleCancel
        {
            get { return GetValue(IsVisibleCancelProperty); }
            set { SetValue(IsVisibleCancelProperty, value); }
        }

        public static readonly RoutedEvent<RoutedEventArgs> ClickOkEvent = RoutedEvent.Register<TitledControl, RoutedEventArgs>(nameof(ClickOk), RoutingStrategies.Bubble);
        public event EventHandler<RoutedEventArgs> ClickOk
        {
            add { AddHandler(ClickOkEvent, value); }
            remove { RemoveHandler(ClickOkEvent, value); }
        }

        public static readonly RoutedEvent<RoutedEventArgs> ClickCancelEvent = RoutedEvent.Register<TitledControl, RoutedEventArgs>(nameof(ClickCancel), RoutingStrategies.Bubble);
        public event EventHandler<RoutedEventArgs> ClickCancel
        {
            add { AddHandler(ClickCancelEvent, value); }
            remove { RemoveHandler(ClickCancelEvent, value); }
        }

        private ICommand? _commandOk, _commandCancel;

        public static readonly DirectProperty<TitledControl, ICommand?> CommandOkProperty = AvaloniaProperty.RegisterDirect<TitledControl, ICommand?>(nameof(CommandOk), buttonOk => buttonOk.CommandOk, (buttonOk, commandOk) => buttonOk.CommandOk = commandOk, enableDataValidation: true);
        public ICommand? CommandOk
        {
            get { return _commandOk; }
            set { SetAndRaise(CommandOkProperty, ref _commandOk, value);   }
        }

        public static readonly DirectProperty<TitledControl, ICommand?> CommandCancelProperty = AvaloniaProperty.RegisterDirect<TitledControl, ICommand?>(nameof(CommandCancel), _buttonCancel => _buttonCancel.CommandCancel, (_buttonCancel, commandCancel) => _buttonCancel.CommandCancel = commandCancel, enableDataValidation: true);
        public ICommand? CommandCancel
        {
            get { return _commandCancel; }
            set { SetAndRaise(CommandCancelProperty, ref _commandCancel, value);  }
        }
    }
}
