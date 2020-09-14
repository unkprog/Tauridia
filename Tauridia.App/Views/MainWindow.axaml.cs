using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;
using Tauridia.Core.Managers;
using Tauridia.Core.Models.Project;

namespace Tauridia.App.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContextChanged += MainWindow_DataContextChanged;
        }

        private void MainWindow_DataContextChanged(object sender, System.EventArgs e)
        {
            if (this.DataContext == null)
                return;

            ((MainWindowViewModel)this.DataContext)._notificationManager = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.TopRight,
                MaxItems = 3
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            

            // Button button = this.FindControl<Button>("TestButton");

            //button.Click += (o, e) =>
            //{
            //    Project prj = new Project() { Name = "FirstProject" };
            //    ProjectFile records = new ProjectFile() { Name = "Записи" };

            //    prj.Files.Add(records);

            //    records.Files.Add(new ProjectFile() { Name = "Запись1" });
            //    records.Files.Add(new ProjectFile() { Name = "Запись2" });


            //    ProjectManager pm = new ProjectManager();
            //    pm.Save(prj);
            //};

            //button.Click += (o, e) =>
            //{
            //    ProjectManager pm = new ProjectManager();
            //    Project prj = pm.ReadProject("FirstProject");
            //};

            //button.Click += (o, e) =>
            //{
            //    ProjectManager pm = new ProjectManager();
            //    pm.ListProjects();
            //};
        }
    }
}
