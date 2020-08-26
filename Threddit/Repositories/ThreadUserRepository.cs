using System;
using System.Collections.Generic;
using System.Linq;
using Threddit.Data;
using Threddit.Models;
using Microsoft.EntityFrameworkCore;

namespace Threddit.Repositories
{
    public class ThreadUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ThreadUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ThreadUser> GetByUserProfileId(int id)
        {
            var All = _context.ThreadUser.Where(tu => tu.UserProfileId == id).ToList();
            return All;
        }

    }
}