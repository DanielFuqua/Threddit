using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threddit.Models
{
    public class FollowUser
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int ActiveUserProfileId { get; set; }

    }
}
