using System;
using System.Collections.Generic;

namespace mr.cooper.mrtwit.models.Tweet
{
    public  class Tweet 
    {

        public Guid TweetId { get; set; }

        public DateTime TweetedOn { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public IList<Guid> Replies { get; set; }//Reply is an another Tweet
        public Guid UserId { get; set; }

        public IList<string> HashTags { get; set; }
        
        public long Likes { get; set; }


    }
}
