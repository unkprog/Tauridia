using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Tauridia.Core.Managers;
using Tauridia.Core.Models.Project;

namespace Tauridia.App.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            Button button = this.FindControl<Button>("TestButton");

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
            button.Click += (o, e) =>
            {
                ProjectManager pm = new ProjectManager();
                Project prj = pm.ReadProject("FirstProject");
            };
        }
    }
}
