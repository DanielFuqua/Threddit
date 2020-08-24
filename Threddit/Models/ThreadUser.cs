﻿using System;
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
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
