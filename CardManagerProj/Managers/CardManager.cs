using CardDbProj.Contexts;
using CardDbProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManagerProj.Managers
{
    public class CardManager : Manager
    {
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
