using System;
using System.Text;

namespace ZanyBaka.Shared.Utils.Lib.Entities.Json
{
    public class EscapeJsonLite
    {
        private readonly Lazy<string> _lazyValue;

        public EscapeJsonLite(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            _lazyValue = new Lazy<string>(() => Escape(input));
        }

        public static implicit operator string(EscapeJsonLite obj)
        {
            return obj.GetValue();
        }

        public string GetValue()
        {
            return _lazyValue.Value;
        }

        public override string ToString()
        {
            return GetValue();
        }

        private static string Escape(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            StringBuilder sb = new StringBuilder(value.Length + 4);
            foreach (char @char in value)
            {
                switch (@char)
                {
                    case '\\':
                    case '"':
                    case '\b':
                    case '\t':
                    case '\n':
                    case '\f':
                    case '\r':
                        sb.Append("\\");
                        sb.Append(@char);
                        break;
                    default:
                        if (@char < ' ')
                        {
                            string t = "000" + string.Format("{0:X}", (int) @char);
                            sb.Append("\\u" + t.Substring(t.Length - 4));
                        }
                        else
                        {
                            sb.Append(@char);
                        }

                        break;
                }
            }

            return sb.ToString();
        }
    }
}