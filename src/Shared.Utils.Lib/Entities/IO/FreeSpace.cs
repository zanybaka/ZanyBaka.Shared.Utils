using System.IO;

namespace ZanyBaka.Shared.Utils.Lib.Entities.IO
{
    public class FreeSpace
    {
        private readonly Drive _drive;
        private long? _value;

        public FreeSpace(Drive drive)
        {
            _drive = drive;
        }

        public long Value()
        {
            if (!_value.HasValue)
            {
                string drive = _drive.ToString();
                try
                {
                    DriveInfo driveInfo = new DriveInfo(drive);
                    _value = driveInfo.AvailableFreeSpace;
                }
                catch (IOException)
                {
                    _value = -1;
                }
            }

            return _value.Value;
        }
    }
}