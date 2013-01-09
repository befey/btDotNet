using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using HtmlAgilityPack;

namespace btDotNet.Models
{
    public class NewsItem
    {
        public int NewsItemId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }

        public NewsItem(GoogleNewsResult result)
        {
            Title = HttpUtility.HtmlDecode(result.titleNoFormatting);
            Content = HttpUtility.HtmlDecode(Strip(result.content));
        }
        public NewsItem(){}

        public string Strip(string text)
        {
            return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }
    }

    
}