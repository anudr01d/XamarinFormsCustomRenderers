﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UIKit;
using Xamarin.Forms;

namespace Huntsman.Mobile.TorontoPU.iOS
{
    public static class FontExtensions
    {
        static readonly Dictionary<ToUIFontKey, UIFont> _toUiFont = new Dictionary<ToUIFontKey, UIFont>();
        public static UIFont ToUIFont(this Font self)
        {
            var size = (float)self.FontSize;
            if (self.UseNamedSize)
            {
                switch (self.NamedSize)
                {
                    case NamedSize.Micro:
                        size = 12;
                        break;
                    case NamedSize.Small:
                        size = 14;
                        break;
                    case NamedSize.Medium:
                        size = 17; // as defined by iOS documentation
                        break;
                    case NamedSize.Large:
                        size = 22;
                        break;
                    default:
                        size = 17;
                        break;
                }
            }

            var bold = self.FontAttributes.HasFlag(FontAttributes.Bold);
            var italic = self.FontAttributes.HasFlag(FontAttributes.Italic);

            if (self.FontFamily != null)
            {
                try
                {
                    if (UIFont.FamilyNames.Contains(self.FontFamily))
                    {
                        var descriptor = new UIFontDescriptor().CreateWithFamily(self.FontFamily);

                        if (bold || italic)
                        {
                            var traits = (UIFontDescriptorSymbolicTraits)0;
                            if (bold)
                                traits = traits | UIFontDescriptorSymbolicTraits.Bold;
                            if (italic)
                                traits = traits | UIFontDescriptorSymbolicTraits.Italic;

                            descriptor = descriptor.CreateWithTraits(traits);
                            return UIFont.FromDescriptor(descriptor, size);
                        }
                    }

                    return UIFont.FromName(self.FontFamily, size);
                }
                catch
                {
                    Debug.WriteLine("Could not load font named: {0}", self.FontFamily);
                }
            }
            if (bold && italic)
            {
                var defaultFont = UIFont.SystemFontOfSize(size);

                var descriptor = defaultFont.FontDescriptor.CreateWithTraits(UIFontDescriptorSymbolicTraits.Bold | UIFontDescriptorSymbolicTraits.Italic);
                return UIFont.FromDescriptor(descriptor, 0);
            }
            if (italic)
                return UIFont.ItalicSystemFontOfSize(size);

            if (bold)
                return UIFont.BoldSystemFontOfSize(size);

            return UIFont.SystemFontOfSize(size);
        }

        internal static bool IsDefault(this Span self)
        {
            return self.FontFamily == null &&
                    self.FontAttributes == FontAttributes.None;
        }


        internal static UIFont ToUIFont(this Entry element)
        {
            return ToUIFont(element.FontFamily, (float)element.FontSize, element.FontAttributes);
        }

        static UIFont _ToUIFont(string family, float size, FontAttributes attributes)
        {
            var bold = (attributes & FontAttributes.Bold) != 0;
            var italic = (attributes & FontAttributes.Italic) != 0;

            if (family != null)
            {
                try
                {
                    UIFont result;

                    if (UIFont.FamilyNames.Contains(family))
                    {
                        var descriptor = new UIFontDescriptor().CreateWithFamily(family);

                        if (bold || italic)
                        {
                            var traits = (UIFontDescriptorSymbolicTraits)0;
                            if (bold)
                                traits = traits | UIFontDescriptorSymbolicTraits.Bold;
                            if (italic)
                                traits = traits | UIFontDescriptorSymbolicTraits.Italic;

                            descriptor = descriptor.CreateWithTraits(traits);
                            result = UIFont.FromDescriptor(descriptor, size);
                            if (result != null)
                                return result;
                        }
                    }

                    result = UIFont.FromName(family, size);

                    if (result != null)
                        return result;
                }
                catch
                {
                    Debug.WriteLine("Could not load font named: {0}", family);
                }
            }

            if (bold && italic)
            {
                var defaultFont = UIFont.SystemFontOfSize(size);


                var descriptor = defaultFont.FontDescriptor.CreateWithTraits(UIFontDescriptorSymbolicTraits.Bold | UIFontDescriptorSymbolicTraits.Italic);
                return UIFont.FromDescriptor(descriptor, 0);
            }
            if (italic)
                return UIFont.ItalicSystemFontOfSize(size);

            if (bold)
                return UIFont.BoldSystemFontOfSize(size);

            return UIFont.SystemFontOfSize(size);
        }

        static UIFont ToUIFont(string family, float size, FontAttributes attributes)
        {
            var key = new ToUIFontKey(family, size, attributes);

            lock (_toUiFont)
            {
                UIFont value;
                if (_toUiFont.TryGetValue(key, out value))
                    return value;
            }

            var generatedValue = _ToUIFont(family, size, attributes);

            lock (_toUiFont)
            {
                UIFont value;
                if (!_toUiFont.TryGetValue(key, out value))
                    _toUiFont.Add(key, value = generatedValue);
                return value;
            }
        }

        struct ToUIFontKey
        {
            internal ToUIFontKey(string family, float size, FontAttributes attributes)
            {
                _family = family;
                _size = size;
                _attributes = attributes;
            }
#pragma warning disable 0414 // these are not called explicitly, but they are used to establish uniqueness. allow it!
            // ReSharper disable once NotAccessedField.Local
            string _family;
            // ReSharper disable once NotAccessedField.Local
            float _size;
            // ReSharper disable once NotAccessedField.Local
            FontAttributes _attributes;
#pragma warning restore 0414
        }
    }
}