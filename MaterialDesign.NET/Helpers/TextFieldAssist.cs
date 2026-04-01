using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialDesign.NET.Helpers
{
    public static class TextFieldAssist
    {
        // Label
        public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached(
            "Label", typeof(string), typeof(TextFieldAssist), new PropertyMetadata(default(string)));

        public static void SetLabel(DependencyObject element, string value) => element.SetValue(LabelProperty, value);
        public static string GetLabel(DependencyObject element) => (string)element.GetValue(LabelProperty);

        // LeadingIcon
        public static readonly DependencyProperty LeadingIconProperty = DependencyProperty.RegisterAttached(
            "LeadingIcon", typeof(object), typeof(TextFieldAssist), new PropertyMetadata(default(object)));

        public static void SetLeadingIcon(DependencyObject element, object value) => element.SetValue(LeadingIconProperty, value);
        public static object GetLeadingIcon(DependencyObject element) => element.GetValue(LeadingIconProperty);

        // TrailingIcon
        public static readonly DependencyProperty TrailingIconProperty = DependencyProperty.RegisterAttached(
            "TrailingIcon", typeof(object), typeof(TextFieldAssist), new PropertyMetadata(default(object)));

        public static void SetTrailingIcon(DependencyObject element, object value) => element.SetValue(TrailingIconProperty, value);
        public static object GetTrailingIcon(DependencyObject element) => element.GetValue(TrailingIconProperty);

        // SupportingText
        public static readonly DependencyProperty SupportingTextProperty = DependencyProperty.RegisterAttached(
            "SupportingText", typeof(string), typeof(TextFieldAssist), new PropertyMetadata(default(string)));

        public static void SetSupportingText(DependencyObject element, string value) => element.SetValue(SupportingTextProperty, value);
        public static string GetSupportingText(DependencyObject element) => (string)element.GetValue(SupportingTextProperty);

        // HasText - ReadOnly attached property to help triggers
        private static readonly DependencyPropertyKey HasTextPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
            "HasText", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(false));

        public static readonly DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

        public static bool GetHasText(DependencyObject element) => (bool)element.GetValue(HasTextProperty);

        // HasSelection - ReadOnly attached property for ComboBox to help with floating label
        private static readonly DependencyPropertyKey HasSelectionPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
            "HasSelection", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(false));

        public static readonly DependencyProperty HasSelectionProperty = HasSelectionPropertyKey.DependencyProperty;

        public static bool GetHasSelection(DependencyObject element) => (bool)element.GetValue(HasSelectionProperty);

        static TextFieldAssist()
        {
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.TextChangedEvent, new TextChangedEventHandler(OnTextChanged));
            EventManager.RegisterClassHandler(typeof(PasswordBox), PasswordBox.PasswordChangedEvent, new RoutedEventHandler(OnPasswordChanged));
            EventManager.RegisterClassHandler(typeof(ComboBox), ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(OnComboBoxSelectionChanged));
        }

        private static void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SetValue(HasTextPropertyKey, textBox.Text.Length > 0);
            }
        }

        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                passwordBox.SetValue(HasTextPropertyKey, passwordBox.Password.Length > 0);
            }
        }

        private static void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                comboBox.SetValue(HasSelectionPropertyKey, comboBox.SelectedIndex != -1);
            }
        }
    }
}
