using System;
using System.Collections;
using System.Collections.Generic;

namespace btDotNet.Controllers
{
    public class NewsItemLocationManager : ILocationManager, IDictionary<string, NewsItemLocation>
    {
        private readonly IDictionary<string, NewsItemLocation> _locations =
            new Dictionary<string, NewsItemLocation>();

        public NewsItemLocationManager(Dictionary<string,NewsItemLocation> locations)
        {
            foreach (KeyValuePair<string,NewsItemLocation> location in locations)
            {
                _locations.Add(location.Key, location.Value);
            }
        }

        public NewsItemLocationManager(){}

        public IEnumerator<KeyValuePair<string, NewsItemLocation>> GetEnumerator()
        {
            return _locations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<string, NewsItemLocation> item)
        {
            _locations.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _locations.Clear();
        }

        public bool Contains(KeyValuePair<string, NewsItemLocation> item)
        {
            return ContainsKey(item.Key) && _locations[item.Key] == item.Value;
        }

        public void CopyTo(KeyValuePair<string, NewsItemLocation>[] array, int arrayIndex)
        {
            _locations.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, NewsItemLocation> item)
        {
            return _locations.Remove(item.Key);
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }
        public bool ContainsKey(string key)
        {
            return _locations.ContainsKey(key);
        }

        public void Add(string key, NewsItemLocation value)
        {
            _locations.Add(key,value);
        }

        public bool Remove(string key)
        {
            return _locations.Remove(key);
        }

        public bool TryGetValue(string key, out NewsItemLocation value)
        {
            return _locations.TryGetValue(key, out value);
        }

        public NewsItemLocation this[string key]
        {
            get { return _locations[key]; }
            set { _locations[key] = value; }
        }

        public ICollection<string> Keys { get; private set; }
        public ICollection<NewsItemLocation> Values { get; private set; }
    }
}