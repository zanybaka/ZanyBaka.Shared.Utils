using System;
using System.Text.RegularExpressions;

namespace ZanyBaka.Shared.Utils.Web.Entities.Html
{
    public class CleanHtmlLite
    {
        private readonly Lazy<string> _lazyValue;

        public CleanHtmlLite(string html, Func<bool> condition)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            _lazyValue = new Lazy<string>(() => CleanHtml(html ?? "", condition));
        }

        public static implicit operator string(CleanHtmlLite obj)
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

        private string CleanHtml(string html, Func<bool> condition)
        {
            if (!condition())
            {
                return html;
            }

            var regex = new Regex("<!-- .*?-->");
            html = regex.Replace(html, "");
            html = html.Replace("&nbsp;", " ");
            return html;
        }
    }
}