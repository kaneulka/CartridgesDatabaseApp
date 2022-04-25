using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.RequestSer
{
    public interface IRequestService
    {
        IEnumerable<Request> GetRequests();
        Request GetRequest(long id);
        void InsertRequest(Request entity);
        void UpdateRequest(Request entity);
        void DeleteRequest(long id);
    }
}
