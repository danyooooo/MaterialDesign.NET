using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesign.NET.Helpers;

namespace MaterialDesign.NET.Controls
{
    /// <summary>
    /// Material Symbols icon variants
    /// </summary>
    public enum MaterialSymbolVariant
    {
        Outlined,
        Rounded,
        Sharp
    }

    /// <summary>
    /// Material Symbols icon control using Unicode code points
    /// More reliable than ligature-based text rendering
    /// </summary>
    public class MaterialSymbolIcon : Control
    {
        static MaterialSymbolIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaterialSymbolIcon), new FrameworkPropertyMetadata(typeof(MaterialSymbolIcon)));
        }

        public MaterialSymbolIcon()
        {
            // Initialize font family and text on construction
            UpdateFontFamily();
            UpdateText();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            // Ensure font and text are set when control is initialized
            // (OnApplyTemplate may be called multiple times)
            UpdateFontFamily();
            UpdateText();
        }

        public static readonly DependencyProperty KindProperty = DependencyProperty.Register(
            nameof(Kind), typeof(MaterialSymbolKind), typeof(MaterialSymbolIcon), 
            new PropertyMetadata(MaterialSymbolKind.Home, OnKindChanged));

        public MaterialSymbolKind Kind
        {
            get => (MaterialSymbolKind)GetValue(KindProperty);
            set => SetValue(KindProperty, value);
        }

        public static readonly DependencyProperty VariantProperty = DependencyProperty.Register(
            nameof(Variant), typeof(MaterialSymbolVariant), typeof(MaterialSymbolIcon),
            new PropertyMetadata(MaterialSymbolVariant.Outlined, OnVariantChanged));

        public MaterialSymbolVariant Variant
        {
            get => (MaterialSymbolVariant)GetValue(VariantProperty);
            set => SetValue(VariantProperty, value);
        }

        public static readonly DependencyProperty FilledProperty = DependencyProperty.Register(
            nameof(Filled), typeof(bool), typeof(MaterialSymbolIcon),
            new PropertyMetadata(false, OnVariantChanged));

        public bool Filled
        {
            get => (bool)GetValue(FilledProperty);
            set => SetValue(FilledProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(MaterialSymbolIcon), new PropertyMetadata(""));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static void OnKindChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MaterialSymbolIcon icon)
            {
                icon.UpdateText();
            }
        }

        private static void OnVariantChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MaterialSymbolIcon icon)
            {
                icon.UpdateFontFamily();
                icon.UpdateText();
            }
        }

        private void UpdateText()
        {
            // Handle None case - show empty
            if (Kind == MaterialSymbolKind.None)
            {
                Text = string.Empty;
                return;
            }

            // Get the Unicode code point for this icon
            var codePoint = MaterialSymbolCodePoints.GetCodePoint(Kind, Variant, Filled);
            
            // Validate and convert code point with proper error handling
            if (!string.IsNullOrEmpty(codePoint) &&
                uint.TryParse(codePoint, System.Globalization.NumberStyles.HexNumber,
                    System.Globalization.CultureInfo.InvariantCulture, out var code) &&
                code <= 0x10FFFF)
            {
                Text = char.ConvertFromUtf32((int)code);
            }
            else
            {
                // Fallback to Home icon (E88A) if code point is invalid
                Text = char.ConvertFromUtf32(0xE88A);
            }
        }

        private void UpdateFontFamily()
        {
            FontFamily = MaterialSymbolsFonts.GetFontFamily(
                Filled 
                    ? (Variant == MaterialSymbolVariant.Rounded ? MaterialSymbolsVariant.RoundedFilled
                       : Variant == MaterialSymbolVariant.Sharp ? MaterialSymbolsVariant.SharpFilled
                       : MaterialSymbolsVariant.OutlinedFilled)
                    : (Variant == MaterialSymbolVariant.Rounded ? MaterialSymbolsVariant.Rounded
                       : Variant == MaterialSymbolVariant.Sharp ? MaterialSymbolsVariant.Sharp
                       : MaterialSymbolsVariant.Outlined));
        }
    }
}
