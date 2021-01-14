using mr.cooper.mrtwit.models;

namespace mr.cooper.mrtwit.services.Interface
{
    public  interface IFeedService
    {
        void AddFeed(Feed feed);
        Feed GetFeed(string userId);


    }
}
