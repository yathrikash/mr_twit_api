using mr.cooper.mrtwit.models;
using System.Collections.Generic;

namespace mr.cooper.mrtwit.services.Interface
{
    public  interface ITweetService
    {
        void ReplyTweet(string tweetId, string replyId);

        void AddTweet(Tweet tweet);

        IList<Tweet> GetTweet(IList<string> tweetIds);
        
        void LikeTweet(string tweetId);

    }
}
