using System;
using ZanyBaka.Shared.Utils.Web.Extensions;

namespace ZanyBaka.Shared.Utils.Web.Entities.Html
{
    public class HtmlAsPlainText
    {
        private readonly Lazy<string> _lazyValue;

        public HtmlAsPlainText(string html)
        {
            _lazyValue = new Lazy<string>(() => (html ?? "").ConvertToPlainText());
        }

        public static implicit operator string(HtmlAsPlainText obj)
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
    }
}