using System.Windows;

namespace MaterialDesign.Demo
{
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = e.Exception.Message;
            if (e.Exception.InnerException != null)
            {
                errorMessage += $"\n\nINNER ERROR: {e.Exception.InnerException.Message}";
            }

            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
