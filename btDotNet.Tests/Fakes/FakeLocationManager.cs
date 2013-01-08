using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using btDotNet.Controllers;

namespace btDotNet.Tests.Fakes
{
    class FakeLocationManager : ILocationManager
    {
        public List<NewsItemLocation> Locations
        {
            get
            {
                return new List<NewsItemLocation> { new NewsItemLocation(@"TestJsonData.json") };
            }
        } 
    }
}
