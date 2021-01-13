

namespace mr.cooper.mrtwit.repository
{
    public interface IDbContext<T> where T : class
    {
          void Add(T data);
    }
}
