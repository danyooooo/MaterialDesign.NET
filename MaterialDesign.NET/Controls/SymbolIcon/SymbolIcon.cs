using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesign.NET.Helpers;

namespace MaterialDesign.NET.Controls
{
    public enum SymbolIconVariant
    {
        Outlined,
        Rounded,
        Sharp
    }

    public class SymbolIcon : Control
    {
        static SymbolIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SymbolIcon), new FrameworkPropertyMetadata(typeof(SymbolIcon)));
        }

        public static readonly DependencyProperty SymbolProperty = DependencyProperty.Register(
            nameof(Symbol), typeof(string), typeof(SymbolIcon), new PropertyMetadata(default(string)));

        public string? Symbol
        {
            get => (string?)GetValue(SymbolProperty);
            set => SetValue(SymbolProperty, value);
        }

        public static readonly DependencyProperty VariantProperty = DependencyProperty.Register(
            nameof(Variant), typeof(SymbolIconVariant), typeof(SymbolIcon), new PropertyMetadata(SymbolIconVariant.Outlined, OnVariantOrFilledChanged));

        public SymbolIconVariant Variant
        {
            get => (SymbolIconVariant)GetValue(VariantProperty);
            set => SetValue(VariantProperty, value);
        }

        public static readonly DependencyProperty FilledProperty = DependencyProperty.Register(
            nameof(Filled), typeof(bool), typeof(SymbolIcon), new PropertyMetadata(false, OnVariantOrFilledChanged));

        public bool Filled
        {
            get => (bool)GetValue(FilledProperty);
            set => SetValue(FilledProperty, value);
        }

        private static void OnVariantOrFilledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SymbolIcon symbolIcon)
            {
                symbolIcon.UpdateFontFamily();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateFontFamily();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            UpdateFontFamily();
        }

        private void UpdateFontFamily()
        {
            // Use the MaterialSymbolsFonts helper to get the appropriate font
            var variant = Filled 
                ? (Variant == SymbolIconVariant.Rounded ? MaterialSymbolsVariant.RoundedFilled 
                   : Variant == SymbolIconVariant.Sharp ? MaterialSymbolsVariant.SharpFilled 
                   : MaterialSymbolsVariant.OutlinedFilled)
                : (Variant == SymbolIconVariant.Rounded ? MaterialSymbolsVariant.Rounded 
                   : Variant == SymbolIconVariant.Sharp ? MaterialSymbolsVariant.Sharp 
                   : MaterialSymbolsVariant.Outlined);

            FontFamily = MaterialSymbolsFonts.GetFontFamily(variant);
        }
    }
}
