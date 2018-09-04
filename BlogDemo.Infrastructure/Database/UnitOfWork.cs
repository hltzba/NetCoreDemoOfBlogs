using BlogDemo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Infrastructure.Database
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MyContext _dbcontext;

        public UnitOfWork(MyContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbcontext.SaveChangesAsync() > 0;
        }
    }
}
