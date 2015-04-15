using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WilderMindApp.Data
{
    public class MessageBoardRepository : IMessageBoardRepository
    {
        MessageBoardContext _ctx;
        public MessageBoardRepository(MessageBoardContext context)
        {
            _ctx = context;
        }

        public IQueryable<Topic> GetTopics()
        {
            return _ctx.Topics;
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return _ctx.Replies.Where(a => a.TopicId == topicId);
        }
    
    }
}