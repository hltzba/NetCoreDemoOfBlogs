using BlogDemo.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Infrastructure.Database
{
    public class MyContextSeed
    {
        public static async Task SeedAsync(MyContext context, ILoggerFactory log, int retry = 0)
        {
            int retryinvailability = retry;
            try
            {
                
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post()
                        {
                            Author = "Jimmy",
                            Content = "Hello,this is 1st content!",
                            PostTime = DateTime.Now,
                            Title = "title one"
                        },
                        new Post()
                        {
                            Author = "Jane",
                            Content = "Hello,this is 2nd content!",
                            PostTime = DateTime.Now,
                            Title = "title two"
                        },
                        new Post()
                        {
                            Author = "Jack",
                            Content = "Hello,this is 3rd content!",
                            PostTime = DateTime.Now,
                            Title = "title three"
                        }
                        );
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryinvailability < 10)
                {
                    retryinvailability++;
                    var logger = log.CreateLogger<MyContextSeed>();
                    logger.LogError(ex.Message);
                    await SeedAsync(context, log, retryinvailability);
                }
            }
        }
    }
}