using System;
using System.Text;
using System.Text.RegularExpressions;
using ZanyBaka.Shared.Utils.Lib.Entities.String;

namespace ZanyBaka.Shared.Utils.Lib.Entities.Json
{
    public class JsonFromRegexMatch
    {
        private readonly Lazy<string> _lazyValue;

        public JsonFromRegexMatch(Match match, string[] groupNames, bool trim)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            if (groupNames == null)
            {
                throw new ArgumentNullException(nameof(groupNames));
            }

            _lazyValue = new Lazy<string>(() => Create(match, groupNames, trim));
        }

        public static implicit operator string(JsonFromRegexMatch obj)
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