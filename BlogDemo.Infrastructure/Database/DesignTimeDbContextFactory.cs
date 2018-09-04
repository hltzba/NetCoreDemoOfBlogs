using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Infrastructure.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyContext>();
            
            builder.UseSqlServer("Server=.;Integrated Security=true;Initial Catalog=BlogDemoDB;");

            return new MyContext(builder.Options);
        }
    }
}
