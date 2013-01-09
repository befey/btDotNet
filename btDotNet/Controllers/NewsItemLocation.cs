using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using btDotNet.Models;

namespace btDotNet.Controllers
{
    public class NewsItemLocation
    {
        private string m_Location;
        
        public string Location
        {
            get { return m_Location; }
            set {
                if (IsValid(value)) m_Location = value;
                else throw new ArgumentException("Location is not valid.", value);
            }
        }

        public NewsItemLocation(Query q)
        {
            Location = "https://ajax.googleapis.com/ajax/services/search/news?v=1.0&rsz=8&q="
                + HttpUtility.HtmlEncode(q.QueryString);
        }

        public NewsItemLocation(string loc)
        {
            Location = loc;
        }

        private bool IsValid(string loc)
        {
            return (File.Exists(loc) || new Regex(@"\Ahttps:\/\/.+").IsMatch(loc));
        }
    }
}