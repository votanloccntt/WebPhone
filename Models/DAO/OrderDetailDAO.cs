using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDetailDAO
    {
        WebPhoneDbContext db = null;

        public OrderDetailDAO()
        {
            db = new WebPhoneDbContext();
        }
        public bool Insert(Order_detail detail)
        {
            try
            {
                db.Order_detail.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List <Order_detail> ViewDetail(int id)
        {
            return db.Order_detail.Where(x => x.Order_id == id).ToList();
        }      
    }
}