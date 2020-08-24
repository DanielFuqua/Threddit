using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threddit.Models
{
    public class PostVote
    {
        public int Id { get; set; }
        public int UserprofileId { get; set; }
        public int PostId { get; set; }
        public bool Vote { get; set; }

    }
}
