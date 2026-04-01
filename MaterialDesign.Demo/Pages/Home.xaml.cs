using System.Windows;
using System.Windows.Controls;
using MaterialDesign.Demo.Domain;

namespace MaterialDesign.Demo.Pages
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                var themeManagerType = Type.GetType("MaterialDesign.NET.Themes.ThemeManager, MaterialDesign.NET");
                if (themeManagerType != null)
                {
                    var toggleMethod = themeManagerType.GetMethod("ToggleTheme");
                    toggleMethod?.Invoke(null, null);
                }
            }
        }

        private void ShowSnackbar_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is Window window)
            {
                var snackbarType = Type.GetType("MaterialDesign.NET.Controls.Snackbar, MaterialDesign.NET");
                if (snackbarType != null)
                {
                    var snackbar = Activator.CreateInstance(snackbarType);
                    var messageProperty = snackbarType.GetProperty("Message");
                    messageProperty?.SetValue(snackbar, "This is a snackbar message!");

                    var showMethod = snackbarType.GetMethod("Show");
                    showMethod?.Invoke(snackbar, new object[] { window });
                }
            }
        }

        private void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is Window window)
            {
                if (window.DataContext is MainViewModel vm)
                {
                    vm.ShowDialog("Simple Dialog", "This is a simple dialog demonstration.");
                }
            }
        }

        private void ShowNotification_Click(object sender, RoutedEventArgs e)
        {
            // Show a badge notification demo
            MessageBox.Show("Notification triggered!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
