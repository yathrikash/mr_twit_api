using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mr.cooper.mrtwit.models.Tweet
{
    public class Feed
    {
        public Guid UserId { get; set; }

        private IList<FeedContent> _feeds;

        public IList<FeedContent> Feeds
        {
            get
            {
                return _feeds.OrderByDescending(x => x.TweetedOn).ToList();
            }
            set
            {
                _feeds = value;
            }
        }

    }

    public class FeedContent
    {

        public DateTime TweetedOn { get; set; }

        public Guid TweetId { get; set; }
    }
}
