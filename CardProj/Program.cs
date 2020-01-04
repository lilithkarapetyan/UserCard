using CardProj.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProj
{
    class Program
    {
        static void Main(string[] args)
        {
            UsersManager um = new UsersManager();
            CardsManager cm = new CardsManager();
            /*um.AddUser("Lilit", "Karapetyan", "37477066436", DateTime.Now);
            um.AddUser("Lilit1", "Karapetyan1", "37477066437", DateTime.Now);

            cm.AddCard("Sali", 10);
            cm.AddCard("Epigraph", 20);*/
            um.AddUserCard("37477066436", 2);
        }
    }
}
