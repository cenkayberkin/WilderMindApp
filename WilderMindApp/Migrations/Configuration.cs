namespace WilderMindApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WilderMindApp.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<WilderMindApp.Data.MessageBoardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WilderMindApp.Data.MessageBoardContext";
            
        }

        protected override void Seed(WilderMindApp.Data.MessageBoardContext context)
        {
            var topic = new Topic()
            {
                Title = "I love MVC",
                createdAt = DateTime.Now,
                Body = "I love Asp.net and i want everyone to learn it.",
                Replies = new List<Reply>() 
                {
                    new Reply()
                    {
                        Body = "I love it too",
                        Created = DateTime.Now
                    },
                    new Reply()
                    {
                        Body = "No way",
                        Created = DateTime.Now
                    },
                    new Reply()
                    {
                        Body = "I hate it man",
                        Created = DateTime.Now
                    }
                }

            };

            var topic1 = new Topic()
            {
                Title = "I do like reading books",
                createdAt = DateTime.Now,
                Body = "I read book generally.",
                Replies = new List<Reply>() 
                {
                    new Reply()
                    {
                        Body = "how can you?",
                        Created = DateTime.Now
                    },
                    new Reply()
                    {
                        Body = "Eh not bad",
                        Created = DateTime.Now
                    },
                    new Reply()
                    {
                        Body = "Wow man, congrats",
                        Created = DateTime.Now
                    }
                }

            };

            context.Topics.Add(topic);
            context.Topics.Add(topic1);
            context.SaveChanges();
        }
    }
}
