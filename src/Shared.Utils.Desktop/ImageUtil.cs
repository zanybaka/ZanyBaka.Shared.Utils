using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace ZanyBaka.Shared.Utils.Desktop
{
    public static class ImageUtil
    {
        public static Image GetImage(this string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException();
            }

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse())
                using (Stream stream = httpWebResponse.GetResponseStream())
                {
                    if (stream == null)
                    {
                        return null;
                    }

                    return Image.FromStream(stream);
                }
        }

        public static string ImageToBase64String(this Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException();
            }

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                byte[] array = ms.ToArray();
                return Convert.ToBase64String(array);
            }
        }

        public static Image Base64StringToImage(this string imageString)
        {
            if (imageString == null)
            {
                throw new ArgumentNullException();
            }

            byte[] array = Convert.FromBase64String(imageString);
            using (MemoryStream ms = new MemoryStream(array))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }
    }
}