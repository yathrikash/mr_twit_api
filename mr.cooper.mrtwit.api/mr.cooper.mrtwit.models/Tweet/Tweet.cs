using System;
using System.Collections.Generic;

namespace mr.cooper.mrtwit.models.Tweet
{
    public  class Tweet 
    {
        public string _id { get; set; }

        public string TweetId { get; set; }

        public DateTime TweetedOn { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public IList<Guid> Replies { get; set; }//Reply is an another Tweet
        public string UserId { get; set; }

        public IList<string> HashTags { get; set; }
        
        public long Likes { get; set; }


    }
}
