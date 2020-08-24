using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threddit.Models
{
    public class CommentVote
    {
        public int Id { get; set; }
        public int UserprofileId { get; set; }
        public int CommentId { get; set; }
        public bool Vote { get; set; }

    }
}
