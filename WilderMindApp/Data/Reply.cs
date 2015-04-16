using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WilderMindApp.Data
{
    [JsonObject(IsReference = true)]
    public class Reply
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public DateTime Created { get; set; }

         [ForeignKey("Topic")]
        public int TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}