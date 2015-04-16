using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WilderMindApp.Data;

namespace WilderMindApp.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository _repo;
        public TopicsController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Topic> GetTopics(bool includeReplies = false)
        {
            IQueryable<Topic> results;

            if (includeReplies == true)
            {
                results = _repo.GetTopicsIncludingReplies();
            }
            else
            {
                results = _repo.GetTopics();
            }

            var topics = results.OrderByDescending(a => a.createdAt)
                        .Take(50)
                        .ToList();

            return topics;
        }

        public HttpResponseMessage Post(Topic newTopic)
        {
            if (newTopic.createdAt == default(DateTime))
            {
                newTopic.createdAt = DateTime.Now;
            }

            if (_repo.AddTopic(newTopic) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newTopic);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}
