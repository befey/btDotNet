using System.Collections;
using System.Collections.Generic;

namespace btDotNet.Controllers
{
    public class NewsItemLocationManager : ILocationManager
    {
        private readonly List<NewsItemLocation> _locations = new List<NewsItemLocation>();

        public List<NewsItemLocation> Locations { get { return _locations; } } 

        public void AddLocation(NewsItemLocation loc)
        {
            _locations.Add(loc);
        }

        public void RemoveLocation(NewsItemLocation loc)
        {
            _locations.Remove(loc);
        }
    }
}