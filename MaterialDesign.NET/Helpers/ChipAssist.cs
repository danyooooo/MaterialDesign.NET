using System;
using System.Windows;
using System.Windows.Input;
using MaterialDesign.NET.Controls;

namespace MaterialDesign.NET.Helpers
{
    public static class ChipAssist
    {
        // Leading Icon
        public static readonly DependencyProperty LeadingIconProperty = DependencyProperty.RegisterAttached(
            "LeadingIcon", typeof(PackIconKind), typeof(ChipAssist), new PropertyMetadata(PackIconKind.None));

        public static void SetLeadingIcon(DependencyObject element, PackIconKind value)
        {
            element.SetValue(LeadingIconProperty, value);
        }

        public static PackIconKind GetLeadingIcon(DependencyObject element)
        {
            return (PackIconKind)element.GetValue(LeadingIconProperty);
        }

        // Trailing Icon
        public static readonly DependencyProperty TrailingIconProperty = DependencyProperty.RegisterAttached(
            "TrailingIcon", typeof(PackIconKind), typeof(ChipAssist), new PropertyMetadata(PackIconKind.None));

        public static void SetTrailingIcon(DependencyObject element, PackIconKind value)
        {
            element.SetValue(TrailingIconProperty, value);
        }

        public static PackIconKind GetTrailingIcon(DependencyObject element)
        {
            return (PackIconKind)element.GetValue(TrailingIconProperty);
        }

        // TrailingIconCommand - Command to execute when trailing icon is clicked
        public static readonly DependencyProperty TrailingIconCommandProperty = DependencyProperty.RegisterAttached(
            "TrailingIconCommand", typeof(ICommand), typeof(ChipAssist), new PropertyMetadata(null));

        public static void SetTrailingIconCommand(DependencyObject element, ICommand value)
        {
            element.SetValue(TrailingIconCommandProperty, value);
        }

        public static ICommand GetTrailingIconCommand(DependencyObject element)
        {
            return (ICommand)element.GetValue(TrailingIconCommandProperty);
        }

        // TrailingIconCommandParameter
        public static readonly DependencyProperty TrailingIconCommandParameterProperty = DependencyProperty.RegisterAttached(
            "TrailingIconCommandParameter", typeof(object), typeof(ChipAssist), new PropertyMetadata(null));

        public static void SetTrailingIconCommandParameter(DependencyObject element, object value)
        {
            element.SetValue(TrailingIconCommandParameterProperty, value);
        }

        public static object GetTrailingIconCommandParameter(DependencyObject element)
        {
            return element.GetValue(TrailingIconCommandParameterProperty);
        }

        // TrailingIconClick event for independent trailing icon interaction (e.g., close button on input chips)
        public static readonly RoutedEvent TrailingIconClickEvent = EventManager.RegisterRoutedEvent(
            "TrailingIconClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChipAssist));

        public static void AddTrailingIconClickHandler(UIElement element, RoutedEventHandler handler)
        {
            element.AddHandler(TrailingIconClickEvent, handler);
        }

        public static void RemoveTrailingIconClickHandler(UIElement element, RoutedEventHandler handler)
        {
            element.RemoveHandler(TrailingIconClickEvent, handler);
        }
    }
}
