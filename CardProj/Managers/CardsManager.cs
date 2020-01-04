using CardProj.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCards.Models.Contexts;

namespace CardProj.Managers
{
    class CardsManager
    {
        private CardsDbContext dbCtx = new CardsDbContext();

        public void AddCard(string sName, double percent)
        {
            Card newCard = new Card
            {
                ShopName = sName,
                Percent = percent
            };

            dbCtx.Cards.Add(newCard);
            dbCtx.SaveChanges();
        }
    }
}
