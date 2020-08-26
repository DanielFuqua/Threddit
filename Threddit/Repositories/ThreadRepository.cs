using System;
using System.Collections.Generic;
using System.Linq;
using Threddit.Data;
using Threddit.Models;
using Microsoft.EntityFrameworkCore;

namespace Threddit.Repositories
{
    public class ThreadRepository
    {
        private readonly ApplicationDbContext _context;

        public ThreadRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Thread> Get(int id)
        {
            var All = _context.Thread.Where(t => t.Id == id).ToList();
            return All;
        }

    }
}