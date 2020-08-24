using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threddit.Models;

namespace Threddit.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Thread> Thread { get; set; }
        public DbSet<ThreadUser> ThreadUser { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostVote> PostVote { get; set; }
        public DbSet<CommentVote> CommentVote { get; set; }
        public DbSet<FollowUser> FollowUser { get; set; }
    }
}
