using System;
using System.Collections.Generic;
using System.Linq;
using Threddit.Data;
using Threddit.Models;
using Microsoft.EntityFrameworkCore;

namespace Threddit.Repositories
{
    public class PostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Post> GetAll()
        {
            var All = _context.Post.ToList();
            return All;
        }  
        
        public List<Post> GetAllByUser(List<ThreadUser> threadUsers)
        {
            var All = _context.Post
                .Where(p => threadUsers.Any(tu => tu.ThreadId == p.ThreadId))
                .ToList();
            return All;
        }

        public Post GetById(int id)
        {
            return _context.Post.FirstOrDefault(p => p.Id == id);
        }




    }
}