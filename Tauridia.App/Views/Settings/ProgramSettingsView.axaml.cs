﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;


namespace Tauridia.App.Views.Settings
{

    public class ProgramSettingsView : UserControl
    {
        public ProgramSettingsView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
       
    }
}
