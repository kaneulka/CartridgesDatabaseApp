using Cartridges.Data;
using Cartridges.Repo.RequestRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.RequestSer
{
    public class RequestService : IRequestService
    {
        private IRequestRepo requestRepository;

        public RequestService(IRequestRepo requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public IEnumerable<Request> GetRequests()
        {
            return requestRepository.GetAll();
        }

        public Request GetRequest(long id)
        {
            return requestRepository.Get(id);
        }

        public void InsertRequest(Request entity)
        {
            requestRepository.Insert(entity);
        }
        public void UpdateRequest(Request entity)
        {
            requestRepository.Update(entity);
        }
        public void DeleteRequest(long id)
        {
            Request request = GetRequest(id);
            requestRepository.Remove(request);
            requestRepository.SaveChanges();
        }
    }
}
