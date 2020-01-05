using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbProj.Contexts;
using DbProj.Models;

namespace CardManagerProj.Managers
{
    public class Manager: IDisposable
    {
        protected readonly CardsDbContext dbCtx = new CardsDbContext();
        
        public void Dispose()
        {
            dbCtx.Dispose();
        }
    }
}
