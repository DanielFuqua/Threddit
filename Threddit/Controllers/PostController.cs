using System.Security.Claims;
using Threddit.Data;
using Threddit.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Threddit.Models;
using System.Collections.Generic;

namespace Threddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostRepository _postRepository;
        private readonly ThreadUserRepository _threadUserRepository;
        private readonly ThreadRepository _threadRepository;

        public PostController(ApplicationDbContext context)
        {
            _postRepository = new PostRepository(context);
            _threadUserRepository = new ThreadUserRepository(context);
            _threadRepository = new ThreadRepository(context);
        }



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAll());
        }

        [HttpGet("{userId}")]
        public IActionResult GetByUser(int userId)
        {
            List<ThreadUser> threadUsers = _threadUserRepository.GetByUserProfileId(userId);


            return Ok(_postRepository.GetAllByUser(threadUsers));
        }


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