using System.IO;
using System.Text;

namespace ZanyBaka.Shared.Utils.Lib.Entities.IO
{
    public class FileContent
    {
        private readonly FilePath _zFile;

        public FileContent(FilePath zFile)
        {
            _zFile = zFile;
        }

        public string Read()
        {
            string path = _zFile.ToString();
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            return "";
        }

        public void Write(string content)
        {
            File.WriteAllText(_zFile.ToString(), content, Encoding.UTF8);
        }
    }
}