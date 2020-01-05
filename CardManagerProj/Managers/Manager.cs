using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDbProj.Contexts;
using CardDbProj.Models;

namespace CardManagerProj.Managers
{
    public class Manager : IDisposable
    {
        protected readonly CardsDbContext dbCtx = new CardsDbContext();

        public void Dispose()
        {
            dbCtx.Dispose();
        }
    }
}
