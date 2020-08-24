using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threddit.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int UserProfileId { get; set; }
        public int PostId { get; set; }

    }
}
