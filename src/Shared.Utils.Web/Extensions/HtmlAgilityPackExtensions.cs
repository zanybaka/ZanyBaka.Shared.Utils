using System;
using System.IO;
using HtmlAgilityPack;

namespace ZanyBaka.Shared.Utils.Web.Extensions
{
    public static class HtmlAgilityPackExtensions
    {
        public static string ConvertToPlainText(this string html)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                return "";
            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            StringWriter sw = new StringWriter();
            ConvertTo(doc.DocumentNode, sw);
            sw.Flush();
            return sw.ToString();
        }

        private static void ConvertContentTo(HtmlNode node, TextWriter outText)
        {
            foreach (HtmlNode subnode in node.ChildNodes)
            {
                ConvertTo(subnode, outText);
            }
        }

        /// <remarks>https://github.com/Clancey/HtmlAgilityPack/blob/master/Html2Txt/HtmlConvert.cs</remarks>
        private static void ConvertTo(HtmlNode node, TextWriter outText)
        {
            string html;
            switch (node.NodeType)
            {
                case HtmlNodeType.Comment:
                    // don't output comments
                    break;

                case HtmlNodeType.Document:
                    ConvertContentTo(node, outText);
                    break;

                case HtmlNodeType.Text:
                    // script and style must not be output
                    string parentName = node.ParentNode.Name;
                    if (parentName == "script" || parentName == "style")
                        break;

                    // get text
                    html = ((HtmlTextNode) node).Text;

                    // is it in fact a special closing node output as text?
                    if (HtmlNode.IsOverlappedClosingElement(html))
                        break;

                    // check the text is meaningful and not a bunch of whitespaces
                    if (html.Trim().Length > 0)
                    {
                        outText.Write(HtmlEntity.DeEntitize(html));
                    }

                    break;

                case HtmlNodeType.Element:
                    switch (node.Name)
                    {
                        case "p":
                            // treat paragraphs as crlf
                            outText.Write(Environment.NewLine);
                            break;
                        case "br":
                            outText.Write(Environment.NewLine);
                            break;
                    }

                    if (node.HasChildNodes)
                    {
                        ConvertContentTo(node, outText);
                    }

                    break;
            }
        }
    }
}