namespace ZanyBaka.Shared.Utils.Lib.Entities.IO
{
    public class Drive
    {
        private readonly string _path;

        public Drive(string path)
        {
            _path = path;
        }

        public override string ToString()
        {
            return _path;
        }
    }
}