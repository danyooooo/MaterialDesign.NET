using System.Windows;
using System.Windows.Controls;

namespace MaterialDesign.NET.Helpers
{
    public static class ListItemAssist
    {
        // Leading Content (Icon, Avatar, Checkbox, etc.)
        public static readonly DependencyProperty LeadingContentProperty = DependencyProperty.RegisterAttached(
            "LeadingContent", typeof(object), typeof(ListItemAssist), new PropertyMetadata(null));

        public static void SetLeadingContent(DependencyObject element, object value) => element.SetValue(LeadingContentProperty, value);
        public static object GetLeadingContent(DependencyObject element) => element.GetValue(LeadingContentProperty);

        // Trailing Content (Icon, Checkbox, Switch, etc.)
        public static readonly DependencyProperty TrailingContentProperty = DependencyProperty.RegisterAttached(
            "TrailingContent", typeof(object), typeof(ListItemAssist), new PropertyMetadata(null));

        public static void SetTrailingContent(DependencyObject element, object value) => element.SetValue(TrailingContentProperty, value);
        public static object GetTrailingContent(DependencyObject element) => element.GetValue(TrailingContentProperty);

        // Supporting Text (Secondary line)
        public static readonly DependencyProperty SupportingTextProperty = DependencyProperty.RegisterAttached(
            "SupportingText", typeof(string), typeof(ListItemAssist), new PropertyMetadata(null));

        public static void SetSupportingText(DependencyObject element, string value) => element.SetValue(SupportingTextProperty, value);
        public static string GetSupportingText(DependencyObject element) => (string)element.GetValue(SupportingTextProperty);

        // Trailing Supporting Text (Metadata like "10 min")
        public static readonly DependencyProperty TrailingSupportingTextProperty = DependencyProperty.RegisterAttached(
            "TrailingSupportingText", typeof(string), typeof(ListItemAssist), new PropertyMetadata(null));

        public static void SetTrailingSupportingText(DependencyObject element, string value) => element.SetValue(TrailingSupportingTextProperty, value);
        public static string GetTrailingSupportingText(DependencyObject element) => (string)element.GetValue(TrailingSupportingTextProperty);
    }
}
