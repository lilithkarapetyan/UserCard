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
                //cm.AddCard("Sali", 30);
                //cm.AddCard("Epigraph", 10);
            }
            using (UserManager um = new UserManager())
            {
                /*
                um.AddUser("Lilit", "Karapetyan", "37477066436", DateTime.Now);

                um.AddUserCard("37477066436", 1);

                um.AddUserCard("37477066436", 2);
                */
                var cards = um.GetUserCards(Guid.Parse("59C6A8F9-0430-EA11-9BA6-3C6AA797F172"));

                foreach (var c in cards)
                {
                    Console.WriteLine(c.ShopName);
                }
                Console.Read();
                
            }
        }
    }
}
