using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaterialDesign.NET.Controls
{
    public class DialogHost : ContentControl
    {
        static DialogHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DialogHost), new FrameworkPropertyMetadata(typeof(DialogHost)));
        }

        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
            nameof(IsOpen), typeof(bool), typeof(DialogHost), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        public static readonly DependencyProperty DialogContentProperty = DependencyProperty.Register(
            nameof(DialogContent), typeof(object), typeof(DialogHost), new PropertyMetadata(null));

        public object DialogContent
        {
            get => GetValue(DialogContentProperty);
            set => SetValue(DialogContentProperty, value);
        }

        public static readonly DependencyProperty DialogContentTemplateProperty = DependencyProperty.Register(
            nameof(DialogContentTemplate), typeof(DataTemplate), typeof(DialogHost), new PropertyMetadata(null));

        public DataTemplate DialogContentTemplate
        {
            get => (DataTemplate)GetValue(DialogContentTemplateProperty);
            set => SetValue(DialogContentTemplateProperty, value);
        }

        public static readonly DependencyProperty CloseOnClickAwayProperty = DependencyProperty.Register(
            nameof(CloseOnClickAway), typeof(bool), typeof(DialogHost), new PropertyMetadata(true));

        public bool CloseOnClickAway
        {
            get => (bool)GetValue(CloseOnClickAwayProperty);
            set => SetValue(CloseOnClickAwayProperty, value);
        }

        public static readonly DependencyProperty CloseDialogCommandProperty = DependencyProperty.Register(
             nameof(CloseDialogCommand), typeof(ICommand), typeof(DialogHost), new PropertyMetadata(null));

        public ICommand CloseDialogCommand
        {
            get => (ICommand)GetValue(CloseDialogCommandProperty);
            set => SetValue(CloseDialogCommandProperty, value);
        }

        public DialogHost()
        {
            CloseDialogCommand = new RelayCommand(_ => IsOpen = false);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var scrim = GetTemplateChild("PART_Scrim") as UIElement;
            if (scrim != null)
            {
                scrim.MouseLeftButtonDown += (s, e) =>
                {
                    if (CloseOnClickAway)
                    {
                        IsOpen = false;
                    }
                };
            }
        }
    }

    // Simple RelayCommand implementation for internal use if not already available in Helpers
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
