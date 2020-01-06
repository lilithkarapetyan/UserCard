using CardDbProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManagerProj.Managers
{
    public class UserManager : Manager
    {
        public void AddUser(string fName, string lName, string pNumber, DateTime bDay)
        {
            User newUser = new User
            {
                FirstName = fName,
                LastName = lName,
                PhoneNumber = pNumber,
                BirthDate = bDay
            };

            dbCtx.Users.Add(newUser);
            dbCtx.SaveChanges();
        }

        public User FindUser(string pNumber)
        {
            return dbCtx.Users.Where(u => u.PhoneNumber == pNumber).FirstOrDefault();
        }

        public void AddUserCard(Guid uId, int cId)      
        {
            UserCard newUserCard = new UserCard
            {
                UserId = uId,
                CardId = cId,
                CreateDate = DateTime.Now
            };

            dbCtx.UsersCards.Add(newUserCard);
            dbCtx.SaveChanges();
        }

        public void AddUserCard(string pNumber, int cId)
        {
            Guid uId = FindUser(pNumber).UserId;
            AddUserCard(uId, cId);
        }

        public Card[] GetUserCards(Guid? id, string pNumber)
        {
            if (id != null)
            {
                return (
                    from uc in dbCtx.UsersCards
                    where uc.UserId == id
                    join card in dbCtx.Cards on uc.CardId equals card.CardId
                    select card
                    ).ToArray();
            }
            else
            {

                return (
                    from uc in dbCtx.UsersCards
                    join user in dbCtx.Users on uc.UserId equals user.UserId
                    join card in dbCtx.Cards on uc.CardId equals card.CardId
                    where user.PhoneNumber == pNumber
                    select card
                    ).ToArray();

            }
        }
    }
}
