using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mr.cooper.mrtwit.models
{
    public class Feed
    {
        public string _id { get; set; }

        public string UserId { get; set; }

        public IList<FeedContent> Feeds { get; set; } = new List<FeedContent>();
        public IList<FeedContent> OrderedFeeds 
        {
            get
            {
                return Feeds.OrderByDescending(x => x.TweetedOn).ToList();
            }
           
        }

    }

    public class FeedContent
    {

        public DateTime TweetedOn { get; set; }

        public string  TweetId { get; set; }
    }
}
