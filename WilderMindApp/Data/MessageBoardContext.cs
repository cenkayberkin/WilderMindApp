using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WilderMindApp.Migrations;

namespace WilderMindApp.Data
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MessageBoardContext,Configuration>() 
                );

        }

        public DbSet<Reply> Replies { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}