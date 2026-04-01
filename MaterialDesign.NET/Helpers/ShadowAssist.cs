using System;
using System.Windows;
using System.Windows.Media.Effects;

namespace MaterialDesign.NET.Helpers
{
    public enum ElevationLevel
    {
        Level0,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    public static class ShadowAssist
    {
        public static readonly DependencyProperty ElevationProperty = DependencyProperty.RegisterAttached(
            "Elevation", typeof(ElevationLevel), typeof(ShadowAssist), new PropertyMetadata(ElevationLevel.Level0, OnElevationChanged));

        public static void SetElevation(DependencyObject element, ElevationLevel value)
        {
            element.SetValue(ElevationProperty, value);
        }

        public static ElevationLevel GetElevation(DependencyObject element)
        {
            return (ElevationLevel)element.GetValue(ElevationProperty);
        }

        private static void OnElevationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                var level = (ElevationLevel)e.NewValue;
                element.Effect = GetDropShadow(level);
            }
        }

        private static DropShadowEffect? GetDropShadow(ElevationLevel level)
        {
            if (level == ElevationLevel.Level0) return null;

            var key = $"MdSysElevation.{level}";
            
            // Try to get from resources first
            if (Application.Current?.TryFindResource(key) is DropShadowEffect effect)
            {
                // Clone since a single Effect instance can't be shared among multiple elements
                return effect.Clone();
            }

            // Fallback to hardcoded values if resources aren't found
            return level switch
            {
                ElevationLevel.Level1 => new DropShadowEffect { BlurRadius = 3, ShadowDepth = 1, Direction = 270, Opacity = 0.2 },
                ElevationLevel.Level2 => new DropShadowEffect { BlurRadius = 6, ShadowDepth = 3, Direction = 270, Opacity = 0.2 },
                ElevationLevel.Level3 => new DropShadowEffect { BlurRadius = 12, ShadowDepth = 6, Direction = 270, Opacity = 0.2 },
                ElevationLevel.Level4 => new DropShadowEffect { BlurRadius = 16, ShadowDepth = 8, Direction = 270, Opacity = 0.2 },
                ElevationLevel.Level5 => new DropShadowEffect { BlurRadius = 24, ShadowDepth = 12, Direction = 270, Opacity = 0.2 },
                _ => null
            };
        }
    }
}
