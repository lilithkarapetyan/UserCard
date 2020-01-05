using DbProj.Models;
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
            return (
                        from u in dbCtx.Users
                        where u.PhoneNumber == pNumber
                        select u
                    )
                    .First<User>();
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

        public Card[] GetUserCards(Guid id)
        {
            return (
                    from uc in dbCtx.UsersCards
                    where uc.UserId == id
                    join card in dbCtx.Cards on uc.CardId equals card.CardId
                    select card
                    ).ToArray();
        }

        public Card[] GetUserCards(string pNumber)
        {
            Guid uId = FindUser(pNumber).UserId;
            return GetUserCards(uId);
        }
    }
}
