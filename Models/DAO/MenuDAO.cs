using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class MenuDAO
    {
        WebPhoneDbContext db = null;
        public MenuDAO()
        {
            db = new WebPhoneDbContext();
        }
        public List<Menu> ListByGroupId(int groupId)
        {

            return db.Menu.Where(x => x.TypeID == groupId && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
