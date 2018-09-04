using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDemo.Core.Entities;
using BlogDemo.Core.Interfaces;
using BlogDemo.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Api.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postdal;
        private readonly IUnitOfWork _unitofwork;

        public PostController(IPostRepository postdal, IUnitOfWork unitofwork)
        {
            this._postdal = postdal;
            this._unitofwork = unitofwork;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postdal.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            Post post = new Post();
            post.Author = "admin";
            post.Content = $"admin post a new content at {DateTime.Now.ToString()}";
            post.PostTime = DateTime.Now;
            post.Title ="new post title";
            _postdal.AddPost(post);
             await _unitofwork.SaveAsync();
            return Ok();
        }
    }
}