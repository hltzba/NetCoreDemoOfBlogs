using BlogDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Infrastructure.Database
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> context):base(context)
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}
