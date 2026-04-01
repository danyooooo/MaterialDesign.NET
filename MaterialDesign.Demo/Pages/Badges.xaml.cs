using System.Windows;
using System.Windows.Controls;

namespace MaterialDesign.Demo.Pages
{
    public partial class Badges : UserControl
    {
        private int _count = 0;

        public Badges()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _count++;
            InteractiveBadge.BadgeContent = _count.ToString();
        }
    }
}
