using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using btDotNet.Controllers;

namespace btDotNet.Tests.Fakes
{
    class FakeLocationManager : ILocationManager
    {
        private List<NewsItemLocation> _locations = new List<NewsItemLocation>();
        public List<NewsItemLocation> Locations
        {
            get
            {
                return _locations;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _locations.GetEnumerator();
        }

        FakeLocationManager()
        {
            _locations.Add(new NewsItemLocation(@"TestJsonData.json"));
        }
    }
}
