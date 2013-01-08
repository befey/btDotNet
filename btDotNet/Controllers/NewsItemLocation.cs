using System;
using System.IO;
using System.Text.RegularExpressions;

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

        public NewsItemLocation(string loc)
        {
            Location = loc;
        }

        private bool IsValid(string loc)
        {
            return (File.Exists(loc) || new Regex(@"\Ahttp:\/\/.+").IsMatch(loc));
        }
    }
}