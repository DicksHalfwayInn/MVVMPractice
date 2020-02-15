using System.Windows;

namespace MVVMPractice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ShellViewModel context;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShellView app = new ShellView();
            context = new ShellViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
