using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace btDotNet.Models
{
    public class GoogleNewsSearchResultsWrapper
    {
        public GoogleNewsSearchResults responseData { get; set; }
        public string responseDetails { get; set; }
        public string responseStatus { get; set; }
    }

    public class GoogleNewsSearchResults
    {
        public GoogleNewsResult[] results { get; set; }
        public GoogleCursor cursor { get; set; }
        public Int32 estimatedResultCount { get; set; }
        public Int32 currentPageIndex { get; set; }
        public string moreResultsUrl { get; set; }
    }

    public class GoogleNewsResult
    {
        public string GsearchResultClass { get; set; }
        public string clusterUrl { get; set; }
        public string content { get; set; }
        public string unescapedUrl { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string titleNoFormatting { get; set; }
        public string location { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string signedRedirectUrl { get; set; }
        public string language { get; set; }
        public GoogleResultImage image { get; set; }
        public GoogleResultRelatedStories[] relatedStories { get; set; }
    }

    public class GoogleResultRelatedStories
    {
        public string unescapedUrl { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string titleNoFormatting { get; set; }
        public string location { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string signedRedirectUrl { get; set; }
        public string language { get; set; }
    }

    public class GoogleResultImage
    {
        public string url { get; set; }
        public string tbUrl { get; set; }
        public string originalContextUrl { get; set; }
        public string publisher { get; set; }
        public Int32 tbWidth { get; set; }
        public Int32 tbHeight { get; set; }
    }

    public class GoogleCursor
    {
        public GooglePages[] pages { get; set; }
    }

    public class GooglePages
    {
        public string start { get; set; }
        public int label { get; set; }
    }
}