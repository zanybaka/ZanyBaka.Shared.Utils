using System.Text;
using System.Web;

namespace ZanyBaka.Shared.Utils.Lib.Entities.Json
{
    public class JsonObject
    {
        private readonly StringBuilder _sb;

        public JsonObject()
        {
            _sb     = new StringBuilder();
            IsEmpty = true;
        }

        public bool IsEmpty { get; private set; }

        public static implicit operator string(JsonObject obj)
        {
            return obj.ToString();
        }

        public override string ToString()
        {
            return $"{{{_sb}}}";
        }

        public void AddKeyValue(string key, string rawValue)
        {
            string value = HttpUtility.JavaScriptStringEncode(rawValue);
            if (_sb.Length != 0)
            {
                _sb.Append(",");
            }

            _sb.Append($"\"{key}\":\"{value}\"");

            IsEmpty = false;
        }
    }
}