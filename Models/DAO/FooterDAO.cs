using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public  class FooterDAO
    {
        WebPhoneDbContext db = null;
        public FooterDAO()
        {
            db = new WebPhoneDbContext();

        }
        public Footer GetFooter()
        {
            return db.Footer.SingleOrDefault(x => x.Status == true);
        }
    }
}
