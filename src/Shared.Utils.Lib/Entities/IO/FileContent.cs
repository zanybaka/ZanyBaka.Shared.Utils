using System;
using System.IO;
using System.Text;

namespace ZanyBaka.Shared.Utils.Lib.Entities.IO
{
    public class FileContent
    {
        private readonly Encoding _encoding;
        private readonly FilePath _zFile;

        public FileContent(FilePath zFile) : this(zFile, Encoding.UTF8)
        {
        }

        public FileContent(FilePath zFile, Encoding encoding)
        {
            if (zFile == null)
            {
                throw new ArgumentNullException(nameof(zFile));
            }

            _zFile    = zFile;
            _encoding = encoding;
        }

        public string Read()
        {
            string path = _zFile.ToString();
            if (File.Exists(path))
            {
                return File.ReadAllText(path, _encoding);
            }

            return null;
        }

        public void Write(string content)
        {
            File.WriteAllText(_zFile.ToString(), content, _encoding);
        }
    }
}