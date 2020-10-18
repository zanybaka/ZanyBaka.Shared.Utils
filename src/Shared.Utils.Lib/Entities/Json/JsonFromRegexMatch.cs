using System.Text;
using System.Text.RegularExpressions;
using ZanyBaka.Shared.Utils.Lib.Entities.String;

namespace ZanyBaka.Shared.Utils.Lib.Entities.Json
{
    public class JsonFromRegexMatch
    {
        private readonly string[] _groupNames;
        private readonly Match _match;
        private readonly bool _trim;

        public JsonFromRegexMatch(Match match, string[] groupNames, bool trim)
        {
            _match      = match;
            _groupNames = groupNames;
            _trim       = trim;
        }

        public static implicit operator string(JsonFromRegexMatch obj)
        {
            return obj.GetValue();
        }

        public string GetValue()
        {
            return Create(_match, _groupNames, _trim);
        }

        private static string Create(Match match, string[] groupNames, bool trim)
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");
            for (int i = 1; i < groupNames.Length; i++) // skip group "0"
            {
                string name     = groupNames[i];
                string rawValue = match.Groups[name]?.Value;
                string value    = new EscapeJsonLite(trim ? new TrimText(rawValue) : rawValue);
                sb.AppendLine($@"  ""{name}"": ""{value}""{(i == groupNames.Length - 1 ? "" : ",")}");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}