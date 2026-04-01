using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesign.NET.Controls;

namespace MaterialDesign.Demo.Pages
{
    public partial class Snackbars : UserControl
    {
        public Snackbars()
        {
            InitializeComponent();
        }

        private void ShowSimpleSnackbar_Click(object sender, RoutedEventArgs e)
        {
            MainSnackbar.Message = "This is a simple message.";
            MainSnackbar.ActionContent = null;
            MainSnackbar.IsActive = true;
        }

        private void ShowActionSnackbar_Click(object sender, RoutedEventArgs e)
        {
            MainSnackbar.Message = "File deleted successfully.";
            MainSnackbar.ActionContent = "UNDO";
            // Simple relay command for demo
            MainSnackbar.ActionCommand = new RelayCommand(param => 
            {
                MainSnackbar.IsActive = false;
                MessageBox.Show("Action Triggered: Undo");
            });
            MainSnackbar.IsActive = true;
        }
    }

    // Reuse the internal RelayCommand if not accessible, or use a standard one. 
    // Since we are in the Demo project, checking if we have one. 
    // Using a local simple implementation for the demo page code-behind convenience.
    public class RelayCommand : System.Windows.Input.ICommand
    {
        private readonly Action<object> _execute;
        public RelayCommand(Action<object> execute) { _execute = execute; }
        public bool CanExecute(object? parameter) => true;
        public void Execute(object? parameter) => _execute(parameter!);
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
