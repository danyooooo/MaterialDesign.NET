using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace MaterialDesign.NET.Helpers
{
    /// <summary>
    /// Available Material Symbols font variants
    /// </summary>
    public enum MaterialSymbolsVariant
    {
        Outlined,
        OutlinedFilled,
        Rounded,
        RoundedFilled,
        Sharp,
        SharpFilled
    }

    /// <summary>
    /// Markup extension for easily accessing Material Symbols fonts in XAML
    /// Usage: FontFamily="{local:MaterialSymbolsFont Outlined}"
    /// </summary>
    public class MaterialSymbolsFontExtension : MarkupExtension
    {
        public MaterialSymbolsVariant Variant { get; set; }

        public MaterialSymbolsFontExtension()
        {
            Variant = MaterialSymbolsVariant.Outlined;
        }

        public MaterialSymbolsFontExtension(MaterialSymbolsVariant variant)
        {
            Variant = variant;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return MaterialSymbolsFonts.GetFontFamily(Variant);
        }
    }

    /// <summary>
    /// Static helper class for accessing Material Symbols fonts
    /// </summary>
    public static class MaterialSymbolsFonts
    {
        private static readonly string BaseUri = "pack://application:,,,/MaterialDesign.NET;component/Resources/Fonts/";
        
        // Cache FontFamily instances to prevent memory leaks and improve performance
        private static readonly Dictionary<MaterialSymbolsVariant, FontFamily> _cache = new();

        static MaterialSymbolsFonts()
        {
            // Pre-initialize all font variants
            foreach (MaterialSymbolsVariant variant in Enum.GetValues(typeof(MaterialSymbolsVariant)))
            {
                try
                {
                    _cache[variant] = CreateFontFamily(variant);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to load font for variant {variant}: {ex.Message}");
                    _cache[variant] = new FontFamily("Arial"); // Fallback
                }
            }
        }

        private static FontFamily CreateFontFamily(MaterialSymbolsVariant variant)
        {
            string uri = variant switch
            {
                MaterialSymbolsVariant.Outlined => $"{BaseUri}MaterialSymbolsOutlined.ttf#Material Symbols Outlined",
                MaterialSymbolsVariant.OutlinedFilled => $"{BaseUri}MaterialSymbolsOutlined_Filled-Regular.ttf#Material Symbols Outlined",
                MaterialSymbolsVariant.Rounded => $"{BaseUri}MaterialSymbolsRounded.ttf#Material Symbols Rounded",
                MaterialSymbolsVariant.RoundedFilled => $"{BaseUri}MaterialSymbolsRounded_Filled-Regular.ttf#Material Symbols Rounded",
                MaterialSymbolsVariant.Sharp => $"{BaseUri}MaterialSymbolsSharp.ttf#Material Symbols Sharp",
                MaterialSymbolsVariant.SharpFilled => $"{BaseUri}MaterialSymbolsSharp_Filled-Regular.ttf#Material Symbols Sharp",
                _ => $"{BaseUri}MaterialSymbolsOutlined.ttf#Material Symbols Outlined"
            };

            return new FontFamily(uri);
        }

        /// <summary>
        /// Gets the FontFamily for the specified Material Symbols variant.
        /// Returns cached instance to prevent memory leaks.
        /// </summary>
        public static FontFamily GetFontFamily(MaterialSymbolsVariant variant)
        {
            if (_cache.TryGetValue(variant, out var fontFamily))
            {
                return fontFamily;
            }

            // Fallback for unknown variants
            return _cache[MaterialSymbolsVariant.Outlined];
        }

        /// <summary>
        /// Validates that all required font files are available.
        /// Call this at application startup to detect missing fonts early.
        /// </summary>
        public static bool ValidateFonts()
        {
            var requiredFonts = new[]
            {
                "MaterialSymbolsOutlined.ttf",
                "MaterialSymbolsOutlined_Filled-Regular.ttf",
                "MaterialSymbolsRounded.ttf",
                "MaterialSymbolsRounded_Filled-Regular.ttf",
                "MaterialSymbolsSharp.ttf",
                "MaterialSymbolsSharp_Filled-Regular.ttf"
            };

            foreach (var font in requiredFonts)
            {
                var uri = new Uri($"{BaseUri}{font}", UriKind.RelativeOrAbsolute);
                try
                {
                    var resource = System.Windows.Application.GetResourceStream(uri);
                    if (resource == null)
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the Outlined variant FontFamily
        /// </summary>
        public static FontFamily Outlined => GetFontFamily(MaterialSymbolsVariant.Outlined);

        /// <summary>
        /// Gets the Outlined Filled variant FontFamily
        /// </summary>
        public static FontFamily OutlinedFilled => GetFontFamily(MaterialSymbolsVariant.OutlinedFilled);

        /// <summary>
        /// Gets the Rounded variant FontFamily
        /// </summary>
        public static FontFamily Rounded => GetFontFamily(MaterialSymbolsVariant.Rounded);

        /// <summary>
        /// Gets the Rounded Filled variant FontFamily
        /// </summary>
        public static FontFamily RoundedFilled => GetFontFamily(MaterialSymbolsVariant.RoundedFilled);

        /// <summary>
        /// Gets the Sharp variant FontFamily
        /// </summary>
        public static FontFamily Sharp => GetFontFamily(MaterialSymbolsVariant.Sharp);

        /// <summary>
        /// Gets the Sharp Filled variant FontFamily
        /// </summary>
        public static FontFamily SharpFilled => GetFontFamily(MaterialSymbolsVariant.SharpFilled);
    }

    /// <summary>
    /// Attached properties for applying Material Symbols fonts to TextBlock and other controls
    /// </summary>
    public static class MaterialSymbolsFontAssist
    {
        public static readonly DependencyProperty VariantProperty =
            DependencyProperty.RegisterAttached(
                "Variant",
                typeof(MaterialSymbolsVariant),
                typeof(MaterialSymbolsFontAssist),
                new FrameworkPropertyMetadata(
                    MaterialSymbolsVariant.Outlined,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits,
                    OnVariantChanged));

        public static MaterialSymbolsVariant GetVariant(DependencyObject obj)
        {
            return (MaterialSymbolsVariant)obj.GetValue(VariantProperty);
        }

        public static void SetVariant(DependencyObject obj, MaterialSymbolsVariant value)
        {
            obj.SetValue(VariantProperty, value);
        }

        private static void OnVariantChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is System.Windows.Controls.Control control)
            {
                control.FontFamily = MaterialSymbolsFonts.GetFontFamily((MaterialSymbolsVariant)e.NewValue);
            }
            else if (d is System.Windows.Documents.TextElement textElement)
            {
                textElement.FontFamily = MaterialSymbolsFonts.GetFontFamily((MaterialSymbolsVariant)e.NewValue);
            }
        }
    }
}
