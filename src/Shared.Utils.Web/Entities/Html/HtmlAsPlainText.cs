using System;
using ZanyBaka.Shared.Utils.Web.Extensions;

namespace ZanyBaka.Shared.Utils.Web.Entities.Html
{
    public class HtmlAsPlainText
    {
        private readonly string _html;
        private readonly Lazy<string> _plainText;

        public HtmlAsPlainText(string html)
        {
            _html      = html;
            _plainText = new Lazy<string>(() => _html.ConvertToPlainText());
        }

        public static implicit operator string(HtmlAsPlainText obj)
        {
            return obj._plainText.Value;
        }

        public override string ToString()
        {
            return _html;
        }
    }
}