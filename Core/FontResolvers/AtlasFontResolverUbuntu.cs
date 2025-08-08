using System;
using PdfSharp.Fonts;

namespace Core.FontResolvers;

public class AtlasFontResolverUbuntu : IFontResolver
{
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            return new FontResolverInfo("ubuntu");
        }

        public byte[] GetFont(string faceName)
        {
            return File.ReadAllBytes("/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf");
        }
}
