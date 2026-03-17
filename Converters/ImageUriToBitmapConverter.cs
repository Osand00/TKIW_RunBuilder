using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TKIW_RunBuilder
{
    // Converts a pack uri (string) to a cached, decoded BitmapImage to reduce decode cost on UI thread.
    // Keeps a small in-memory cache to avoid repeated decodes.
    public class ImageUriToBitmapConverter : IValueConverter
    {
        private static readonly ConcurrentDictionary<string, BitmapImage> _cache = new ConcurrentDictionary<string, BitmapImage>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string uriString || string.IsNullOrEmpty(uriString))
                return null;

            // Try get from cache
            if (_cache.TryGetValue(uriString, out var bmp))
                return bmp;

            try
            {
                var uri = new Uri(uriString, UriKind.Absolute);
                var bi = new BitmapImage();
                // Decode on background thread by freezing after initialization
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad; // load into memory so we can close stream
                bi.UriSource = uri;
                bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache; // ensure fresh read
                bi.EndInit();
                bi.Freeze();
                _cache[uriString] = bi;
                return bi;
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
