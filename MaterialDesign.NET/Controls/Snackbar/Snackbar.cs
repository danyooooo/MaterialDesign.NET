using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MaterialDesign.NET.Controls
{
    public class Snackbar : ContentControl
    {
        private DispatcherTimer _autoCloseTimer;

        static Snackbar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Snackbar), new FrameworkPropertyMetadata(typeof(Snackbar)));
        }

        public Snackbar()
        {
            _autoCloseTimer = new DispatcherTimer();
            _autoCloseTimer.Tick += AutoCloseTimer_Tick;
        }

        #region Dependency Properties

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            nameof(Message), typeof(object), typeof(Snackbar), new PropertyMetadata(null));

        public object? Message
        {
            get => GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly DependencyProperty ActionContentProperty = DependencyProperty.Register(
            nameof(ActionContent), typeof(object), typeof(Snackbar), new PropertyMetadata(null));

        public object? ActionContent
        {
            get => GetValue(ActionContentProperty);
            set => SetValue(ActionContentProperty, value);
        }

        public static readonly DependencyProperty ActionCommandProperty = DependencyProperty.Register(
            nameof(ActionCommand), typeof(ICommand), typeof(Snackbar), new PropertyMetadata(null));

        public ICommand? ActionCommand
        {
            get => (ICommand?)GetValue(ActionCommandProperty);
            set => SetValue(ActionCommandProperty, value);
        }

        public static readonly DependencyProperty ActionCommandParameterProperty = DependencyProperty.Register(
            nameof(ActionCommandParameter), typeof(object), typeof(Snackbar), new PropertyMetadata(null));

        public object? ActionCommandParameter
        {
            get => GetValue(ActionCommandParameterProperty);
            set => SetValue(ActionCommandParameterProperty, value);
        }

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
            nameof(IsActive), typeof(bool), typeof(Snackbar), new PropertyMetadata(false, OnIsActiveChanged));

        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }

        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
            nameof(Duration), typeof(TimeSpan), typeof(Snackbar), new PropertyMetadata(TimeSpan.FromSeconds(3)));

        public TimeSpan Duration
        {
            get => (TimeSpan)GetValue(DurationProperty);
            set => SetValue(DurationProperty, value);
        }

        #endregion

        private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var snackbar = (Snackbar)d;
            if ((bool)e.NewValue)
            {
                snackbar.StartTimer();
            }
            else
            {
                snackbar.StopTimer();
            }
        }

        private void StartTimer()
        {
            StopTimer();
            if (Duration > TimeSpan.Zero)
            {
                _autoCloseTimer.Interval = Duration;
                _autoCloseTimer.Start();
            }
        }

        private void StopTimer()
        {
            _autoCloseTimer.Stop();
        }

        private void AutoCloseTimer_Tick(object sender, EventArgs e)
        {
            StopTimer();
            IsActive = false;
        }
    }
}
