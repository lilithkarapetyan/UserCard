using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardManagerProj.Managers;

namespace CardAppProj
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CardManager cm = new CardManager())
            {
                cm.AddCard("Aldo", 20);
            }
            using (UserManager um = new UserManager())
            {
                um.AddUser("Lilit", "Karapetyan", "37477066436", DateTime.Now);
                um.AddUserCard("37477066436", 1);
            }
        }
    }
}
