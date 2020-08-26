using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threddit.Models
{
    public class ThreadUser
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int UserProfileId { get; set; }
        public bool Moderator { get; set; }
        public bool Creator { get; set; }
    }
}
