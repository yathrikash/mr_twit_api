

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mr.cooper.mrtwit.repository
{
    public interface IDbContext<T> where T : class
    {
          void Add(T data);

        IEnumerable<T> Get(string userId);


        IEnumerable<T> Get(IList<string> userIds);

        void Update(T updatedData);

        void Delete(string userId);

    }
}
