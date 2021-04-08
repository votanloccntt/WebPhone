using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserModel
    {
        private WebPhoneDbContext context = null;
        public UserModel()
        {
            context = new WebPhoneDbContext();
        }

        public bool Login(string userName, string password)
        {
            object[] sqlParams= new SqlParameter[]
            {

                new SqlParameter("@UserName",userName),
                new SqlParameter("@Password",password)
            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @UserName,@Password", sqlParams).SingleOrDefault();
                return res;
        }
    }
}
