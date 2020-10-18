using System;
using System.IO;

namespace ZanyBaka.Shared.Utils.Lib.Entities.IO
{
    public class FreeSpace
    {
        private readonly Drive _drive;
        private long? _lazyValue;

        public FreeSpace(Drive drive)
        {
            if (drive == null)
            {
                throw new ArgumentNullException(nameof(drive));
            }

            _drive = drive;
        }

        /// <returns>Returns -1 if any issues with the specified drive</returns>
        public long GetValue()
        {
            if (_lazyValue.HasValue)
            {
                return _lazyValue.Value;
            }

            string drive = _drive.ToString();
            try
            {
                DriveInfo driveInfo = new DriveInfo(drive);
                _lazyValue = driveInfo.AvailableFreeSpace;
            }
            catch (IOException)
            {
                _lazyValue = -1;
            }

            return _lazyValue.Value;
        }
    }
}