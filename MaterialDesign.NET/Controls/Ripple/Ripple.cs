using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MaterialDesign.NET.Controls
{
    [TemplatePart(Name = TemplateLayerName, Type = typeof(Canvas))]
    public class Ripple : ContentControl
    {
        private const string TemplateLayerName = "PART_Layer";
        private Canvas? _canvas;

        static Ripple()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Ripple), new FrameworkPropertyMetadata(typeof(Ripple)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _canvas = GetTemplateChild(TemplateLayerName) as Canvas;
        }

        public static readonly DependencyProperty FeedbackProperty = DependencyProperty.Register(
            nameof(Feedback), typeof(Brush), typeof(Ripple), new PropertyMetadata(null));

        public Brush? Feedback
        {
            get => (Brush?)GetValue(FeedbackProperty);
            set => SetValue(FeedbackProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius), typeof(CornerRadius), typeof(Ripple), new PropertyMetadata(default(CornerRadius)));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty IsCenteredProperty = DependencyProperty.Register(
            nameof(IsCentered), typeof(bool), typeof(Ripple), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets whether the ripple should start from the center.
        /// Useful for keyboard focus ripples.
        /// </summary>
        public bool IsCentered
        {
            get => (bool)GetValue(IsCenteredProperty);
            set => SetValue(IsCenteredProperty, value);
        }

        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
            nameof(Duration), typeof(double), typeof(Ripple), new PropertyMetadata(350.0));

        /// <summary>
        /// Gets or sets the ripple animation duration in milliseconds.
        /// Default is 350ms (MD3 Expressive Fast Effects).
        /// </summary>
        public double Duration
        {
            get => (double)GetValue(DurationProperty);
            set => SetValue(DurationProperty, value);
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            if (_canvas != null)
            {
                var point = IsCentered ? new Point(ActualWidth / 2, ActualHeight / 2) : e.GetPosition(this);
                CreateRipple(point);
            }
        }

        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnGotKeyboardFocus(e);
            if (_canvas != null && IsCentered)
            {
                // Create centered ripple for keyboard focus
                var point = new Point(ActualWidth / 2, ActualHeight / 2);
                CreateRipple(point, isKeyboardRipple: true);
            }
        }

        private void CreateRipple(Point point, bool isKeyboardRipple = false)
        {
            var ellipse = new Ellipse
            {
                Width = 0,
                Height = 0,
                Fill = Feedback ?? Foreground,
                Opacity = 0.5
            };

            Canvas.SetLeft(ellipse, point.X);
            Canvas.SetTop(ellipse, point.Y);
            _canvas.Children.Add(ellipse);

            var maxSize = Math.Max(ActualWidth, ActualHeight) * 2;
            var duration = TimeSpan.FromMilliseconds(Duration);

            // Use MD3 motion easing (Expressive Default Effects) via CubicEase
            var easing = new CubicEase { EasingMode = EasingMode.EaseOut };

            var widthAnim = new DoubleAnimation(maxSize, duration) { EasingFunction = easing };
            var heightAnim = new DoubleAnimation(maxSize, duration) { EasingFunction = easing };
            var opacityAnim = new DoubleAnimation(0, duration);
            var leftAnim = new DoubleAnimation(point.X - maxSize / 2, duration) { EasingFunction = easing };
            var topAnim = new DoubleAnimation(point.Y - maxSize / 2, duration) { EasingFunction = easing };

            opacityAnim.Completed += (s, ev) =>
            {
                if (_canvas != null)
                {
                    _canvas.Children.Remove(ellipse);
                }
            };

            ellipse.BeginAnimation(WidthProperty, widthAnim);
            ellipse.BeginAnimation(HeightProperty, heightAnim);
            ellipse.BeginAnimation(OpacityProperty, opacityAnim);
            ellipse.BeginAnimation(Canvas.LeftProperty, leftAnim);
            ellipse.BeginAnimation(Canvas.TopProperty, topAnim);
        }
    }
}
