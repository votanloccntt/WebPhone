using Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDAO
    {
        WebPhoneDbContext db = null;
        public UserDAO()
        {
            db = new WebPhoneDbContext();
        }
        public IEnumerable<User> ListAllPaging(string sreachString, int page, int pageSize)
        {
            IQueryable<User> model = db.User;
            if (!string.IsNullOrEmpty(sreachString))
            {
                model = model.Where(x => x.Username.Contains(sreachString) || x.Password.Contains(sreachString) || x.Name.Contains(sreachString)
                );
            }
            return model.OrderByDescending(x => x.User_id).ToPagedList(page, pageSize);
        }
        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.User_id;
        }
         public bool Update(User entity)
        {
            var user = db.User.Find(entity.User_id);
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.Name = entity.Name;        
            db.SaveChanges();
            return true;
        }
        public User GetById(string userName)
        {
            return db.User.SingleOrDefault(x => x.Username == userName);
        }
        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Login(string userName, string passWord)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@PassWord",passWord),
            };
            var res =
                db.Database.SqlQuery<bool>("Sp_Account_Login @UserName, @PassWord", sqlParams).SingleOrDefault();
            return res;
        }
        public bool CheckUserName(string userName)
        {
            return db.User.Count(x => x.Username == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.User.Count(x => x.Email == email) > 0;
        }
    }
}
