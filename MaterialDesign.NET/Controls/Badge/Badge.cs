using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialDesign.NET.Controls
{
    public class Badge : ContentControl
    {
        static Badge()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Badge), new FrameworkPropertyMetadata(typeof(Badge)));
        }

        public static readonly DependencyProperty BadgeContentProperty = DependencyProperty.Register(
            nameof(BadgeContent), typeof(object), typeof(Badge), new PropertyMetadata(null));

        public object BadgeContent
        {
            get => GetValue(BadgeContentProperty);
            set => SetValue(BadgeContentProperty, value);
        }

        public static readonly DependencyProperty BadgeBackgroundProperty = DependencyProperty.Register(
            nameof(BadgeBackground), typeof(Brush), typeof(Badge), new PropertyMetadata(Brushes.Red)); // Default to Red/Error

        public Brush BadgeBackground
        {
            get => (Brush)GetValue(BadgeBackgroundProperty);
            set => SetValue(BadgeBackgroundProperty, value);
        }

        public static readonly DependencyProperty BadgeForegroundProperty = DependencyProperty.Register(
            nameof(BadgeForeground), typeof(Brush), typeof(Badge), new PropertyMetadata(Brushes.White)); // Default to White/OnError

        public Brush BadgeForeground
        {
            get => (Brush)GetValue(BadgeForegroundProperty);
            set => SetValue(BadgeForegroundProperty, value);
        }

        public static readonly DependencyProperty ShowBadgeProperty = DependencyProperty.Register(
            nameof(ShowBadge), typeof(bool), typeof(Badge), new PropertyMetadata(true));

        public bool ShowBadge
        {
            get => (bool)GetValue(ShowBadgeProperty);
            set => SetValue(ShowBadgeProperty, value);
        }
    }
}
