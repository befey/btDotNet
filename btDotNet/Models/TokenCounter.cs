using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace btDotNet.Models
{
    public class TokenCounter : Dictionary<string, Int32>
    {
        public TokenCounter(IEnumerable<NewsItem> newsItems)
        {
            var tempDict = new Dictionary<string, int>();
            foreach (NewsItem n in newsItems)
            {
                var matches = Regex.Matches(n.Content.ToLower(), "[a-zA-Z]+");
                foreach (Match match in matches)
                {
                    if (match.ToString().Length>3)
                    {
                        if (tempDict.ContainsKey(match.ToString())) tempDict[match.ToString()]++;
                        else tempDict.Add(match.ToString(), 1);
                    }
                }
            }
            int ctr = 0;
            foreach (var item in tempDict.OrderByDescending(key => key.Value))
            {
                if (ctr < 200)
                {
                    this.Add(item.Key, item.Value);
                    ctr++;
                }
                else break;
            }
        }
    }
}