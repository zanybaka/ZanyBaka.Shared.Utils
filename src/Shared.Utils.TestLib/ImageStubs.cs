using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ZanyBaka.Shared.Utils.TestLib
{
    public static class ImageStubs
    {
        public static Image CreateImageStub()
        {
            MemoryStream ms = new MemoryStream();
            new Bitmap(10, 10).Save(ms, ImageFormat.Jpeg);
            return Image.FromStream(ms);
        }
    }
}