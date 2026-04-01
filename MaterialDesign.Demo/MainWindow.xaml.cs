using System.Windows;
using MaterialDesign.Demo.Domain;

namespace MaterialDesign.Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
