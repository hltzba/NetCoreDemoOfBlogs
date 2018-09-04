using BlogDemo.Core.Entities;
using BlogDemo.Core.Interfaces;
using BlogDemo.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Infrastructure.Repositories
{
    public class PostRepository: IPostRepository
    {
        private readonly MyContext context;

        public PostRepository(MyContext context)
        {
            this.context = context;
        }

        public void AddPost(Post post)
        {
            context.Posts.Add(post);
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await context.Posts.ToListAsync();
        }
    }
}
