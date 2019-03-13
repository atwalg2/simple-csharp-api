using simple_csharp_api.Repository;
using System.Collections.Generic;
using System.Linq;

namespace simple_csharp_api.users
{
    public class UserRepository : IRepository<User>
    {
        private readonly DatabaseContext db;

        public UserRepository(DatabaseContext dbCtx)
        {
            db = dbCtx;
        }

        public List<User> Find()
        {
            return db.users
                .OrderBy(u => u.surname)
                .ToList();
        }

        public User Get(int id)
        {
            var result = (from o in db.users where o.id == id select o).FirstOrDefault();
            return result;
        }

        public void Create(User entity)
        {
            db.users.Add(entity);
            db.SaveChanges();
        }

        public void Delete(User entity)
        {
            db.users.Remove(entity);
            db.SaveChanges();
        }

        //public IEnumerable<User> getUsersByCountryCode(string countryCode)
        //{
        //    return db.Users
        //        .Where(u => u.country_code == countryCode)
        //        .ToList();
        //}
    }
}
