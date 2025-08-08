using System;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;

namespace Core.Helpers;

public static class AtlasHelperBarCode
{
    public static MemoryStream GetCodeFromText(string text)
    {
        ZXing.Common.EncodingOptions Options = new ZXing.Common.EncodingOptions()
        {
            Height = 50
        };

        PngEncoder encoder = new PngEncoder()
        {
            CompressionLevel = PngCompressionLevel.Level8
        };

        ZXing.ImageSharp.BarcodeWriter<Rgba32> codeWriter = new ZXing.ImageSharp.BarcodeWriter<Rgba32>
        {
            Format = BarcodeFormat.CODE_128,
            Options = Options
        };

        SixLabors.ImageSharp.Image<Rgba32> imageSaved = codeWriter.Write(text);

        MemoryStream ms = new MemoryStream();
        
        imageSaved.Save(ms, encoder);
        return ms;
    }

}
