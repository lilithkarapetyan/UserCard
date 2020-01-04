using CardProj.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCards.Models.Contexts;

namespace CardProj.Managers
{
    class UsersManager
    {
        private CardsDbContext dbCtx = new CardsDbContext();

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

        public object[] GetUserCards(Guid id)
        {
            return (from uc in dbCtx.UsersCards
                    where uc.UserId == id
                    select new
                    {
                        uc.CardId,
                        uc.CreateDate
                    }).ToArray();
        }

        public object[] GetUserCards(string pNumber)
        {
            Guid uId = FindUser(pNumber).UserId;
            return GetUserCards(uId);
        }
    }
}
