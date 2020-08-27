using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Threddit.Data;
using Threddit.Repositories;

namespace Threddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadController : ControllerBase
    {
        private readonly ThreadRepository _threadRepository;

        public ThreadController(ApplicationDbContext context)
        {
            _threadRepository = new ThreadRepository(context);
        }



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_threadRepository.GetAll());
        }

        //[HttpGet("{userId}")]
        //public IActionResult GetByUser(int userId)
        //{
        //    List<ThreadUser> threadUsers = _threadUserRepository.GetByUserProfileId(userId);


        //    return Ok(_postRepository.GetAllByUser(threadUsers));
        //}


        //[Authorize]
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var post = _postRepository.GetById(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(post);
        //}
    }
}
