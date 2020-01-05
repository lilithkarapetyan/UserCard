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
                cm.AddCard("Sali", 30);
            }
            using (UserManager um = new UserManager())
            {   
                //um.AddUser("Lilit", "Karapetyan", "37477066436", DateTime.Now);
                um.AddUserCard("37477066436", 2);
               // um.GetUserCards(Guid.Parse("21E45A4B-F52F-EA11-9BA6-3C6AA797F172"));
            }
        }
    }
}
