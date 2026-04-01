using System;
using System.Windows;

namespace MaterialDesign.NET.Themes
{
    /// <summary>
    /// Manages runtime theme switching between Light and Dark themes
    /// </summary>
    public static class ThemeManager
    {
        private const string ThemeDictionaryKey = "ThemeDictionary";
        private const string LightThemeUri = "Themes/Colors/Light.xaml";
        private const string DarkThemeUri = "Themes/Colors/Dark.xaml";

        /// <summary>
        /// Identifies the CurrentTheme attached property
        /// </summary>
        public static readonly DependencyProperty CurrentThemeProperty =
            DependencyProperty.RegisterAttached(
                "CurrentTheme",
                typeof(string),
                typeof(ThemeManager),
                new FrameworkPropertyMetadata("Light", FrameworkPropertyMetadataOptions.Inherits, OnCurrentThemeChanged));

        public static string GetCurrentTheme(DependencyObject obj) => (string)obj.GetValue(CurrentThemeProperty);
        public static void SetCurrentTheme(DependencyObject obj, string value) => obj.SetValue(CurrentThemeProperty, value);

        /// <summary>
        /// Gets the current theme name
        /// </summary>
        public static string CurrentThemeName { get; private set; } = "Light";

        /// <summary>
        /// Event raised when the theme changes
        /// </summary>
        public static event EventHandler<ThemeChangedEventArgs>? ThemeChanged;

        /// <summary>
        /// Sets the application theme to Light or Dark
        /// </summary>
        /// <param name="themeName">"Light" or "Dark"</param>
        public static void SetTheme(string themeName)
        {
            if (string.IsNullOrEmpty(themeName))
                throw new ArgumentNullException(nameof(themeName));

            var themeUri = themeName.ToLowerInvariant() switch
            {
                "light" => new Uri(LightThemeUri, UriKind.Relative),
                "dark" => new Uri(DarkThemeUri, UriKind.Relative),
                _ => throw new ArgumentException($"Unknown theme: {themeName}. Use 'Light' or 'Dark'.", nameof(themeName))
            };

            if (Application.Current == null)
            {
                CurrentThemeName = themeName;
                return;
            }

            var themeDict = FindThemeDictionary();
            if (themeDict != null)
            {
                var oldTheme = CurrentThemeName;
                themeDict.Source = themeUri;
                CurrentThemeName = themeName;

                ThemeChanged?.Invoke(null, new ThemeChangedEventArgs(oldTheme, themeName));
            }
        }

        /// <summary>
        /// Toggles between Light and Dark themes
        /// </summary>
        public static void ToggleTheme()
        {
            SetTheme(CurrentThemeName == "Light" ? "Dark" : "Light");
        }

        /// <summary>
        /// Initializes the theme manager. Call this in App.xaml.cs OnStartup
        /// </summary>
        public static void Initialize()
        {
            // Ensure theme dictionary exists
            if (Application.Current != null && FindThemeDictionary() == null)
            {
                AddThemeDictionary("Light");
            }
        }

        /// <summary>
        /// Initializes with a specific theme
        /// </summary>
        public static void Initialize(string themeName)
        {
            if (Application.Current != null)
            {
                AddThemeDictionary(themeName);
                CurrentThemeName = themeName;
            }
        }

        private static ResourceDictionary? FindThemeDictionary()
        {
            if (Application.Current == null) return null;

            foreach (ResourceDictionary dict in Application.Current.Resources.MergedDictionaries)
            {
                if (dict.Source != null &&
                    (dict.Source.OriginalString.Contains("Themes/Colors/Light.xaml") ||
                     dict.Source.OriginalString.Contains("Themes/Colors/Dark.xaml")))
                {
                    return dict;
                }
            }
            return null;
        }

        private static void AddThemeDictionary(string themeName)
        {
            var themeUri = themeName.ToLowerInvariant() switch
            {
                "light" => new Uri(LightThemeUri, UriKind.Relative),
                "dark" => new Uri(DarkThemeUri, UriKind.Relative),
                _ => new Uri(LightThemeUri, UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary
            {
                Source = themeUri
            });
        }

        private static void OnCurrentThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is string themeName)
            {
                SetTheme(themeName);
            }
        }
    }

    /// <summary>
    /// Event args for theme changed event
    /// </summary>
    public class ThemeChangedEventArgs : EventArgs
    {
        public string OldTheme { get; }
        public string NewTheme { get; }

        public ThemeChangedEventArgs(string oldTheme, string newTheme)
        {
            OldTheme = oldTheme;
            NewTheme = newTheme;
        }
    }
}
