using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threddit.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserProfileId { get; set; }
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
