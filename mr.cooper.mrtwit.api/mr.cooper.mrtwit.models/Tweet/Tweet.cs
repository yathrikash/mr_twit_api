using System;
using System.Collections.Generic;

namespace mr.cooper.mrtwit.models
{
    public  class Tweet 
    {
        public string _id { get; set; }

        public string TweetId { get; set; }

        public  MrTwitEnums.TweetType Type { get; set; }
        public DateTime TweetedOn { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public IList<string> Replies { get; set; }//Reply is an another Tweet or just string content
        public string UserId { get; set; }

        public IList<string> HashTags { get; set; }
        
        public long Likes { get; set; }


    }
}
