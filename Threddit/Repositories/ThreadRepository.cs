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
        public List<Thread> GetAll()
        {
            var All = _context.Thread.ToList();
            return All;
        }

        //public List<Thread> GetAllFollowedThreads(int id)
        //{

        //}

    }
}