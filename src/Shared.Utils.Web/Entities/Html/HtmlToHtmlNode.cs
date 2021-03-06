using System;
using System.Diagnostics;
using HtmlAgilityPack;

namespace ZanyBaka.Shared.Utils.Web.Entities.Html
{
    public class HtmlToHtmlNode
    {
        private readonly string _html;
        private readonly Lazy<HtmlNode> _lazyValue;

        public HtmlToHtmlNode(string html)
        {
            _html      = html;
            _lazyValue = new Lazy<HtmlNode>(() => ParseHtml(_html));
        }

        public static implicit operator HtmlNode(HtmlToHtmlNode obj)
        {
            return obj.GetValue();
        }

        public HtmlNode GetValue()
        {
            return _lazyValue.Value;
        }

        public override string ToString()
        {
            return _html;
        }

        private static HtmlNode ParseHtml(string content)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.OptionFixNestedTags = true;
            doc.LoadHtml(content);
            if (doc.ParseErrors != null)
            {
                foreach (HtmlParseError error in doc.ParseErrors)
                {
                    if (error.Code == HtmlParseErrorCode.EndTagNotRequired)
                    {
                        continue;
                    }

                    Trace.TraceError($"Error in the HTML content: {error.Reason}");
                }
            }

            return doc.DocumentNode;
        }
    }
}