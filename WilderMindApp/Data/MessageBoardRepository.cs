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

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddTopic(Topic newTopic)
        {
            try
            {
                _ctx.Topics.Add(newTopic);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {
            return _ctx.Topics.Include("Replies");
        }

        public bool AddReply(Reply newReply)
        {
            try
            {
                _ctx.Replies.Add(newReply);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}