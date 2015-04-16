using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WilderMindApp.Data;

namespace WilderMindApp.Controllers
{
    public class RepliesController : ApiController
    {
        private IMessageBoardRepository _repo;
        public RepliesController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Reply> Get(int topicid)
        {
            var replies = _repo.GetRepliesByTopic(topicid)
                .Take(50)
                .ToList();

            return replies;
        }
        public HttpResponseMessage Post(int topicId, Reply newReply)
        {
            if (newReply.Created == default(DateTime))
            {
                newReply.Created = DateTime.Now;
            }
            newReply.TopicId = topicId;

            if (_repo.AddReply(newReply) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newReply);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
