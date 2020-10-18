using System;

namespace ZanyBaka.Shared.Utils.Lib.Utils
{
    public static class CLog
    {
        public static void Error(string message, Exception ex)
        {
            Console.WriteLine($"[{DateTime.UtcNow} ERROR] {message}:{Environment.NewLine}{ex}");
        }

        public static void Error(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow} ERROR] {message}");
        }

        public static void Info(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow}  INFO] {message}");
        }

        public static void Warn(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow}  WARN] {message}");
        }

        public static void Verbose(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow}  VERB] {message}");
        }

        public static void Debug(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow} DEBUG] {message}");
        }
    }
}