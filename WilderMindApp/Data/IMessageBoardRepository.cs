﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilderMindApp.Data
{
    public interface IMessageBoardRepository
    {
        IQueryable<Topic> GetTopics();
        IQueryable<Reply> GetRepliesByTopic(int topicId);

    }
}
