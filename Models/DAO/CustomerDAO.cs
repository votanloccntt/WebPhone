using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class CustomerDAO
    {
        WebPhoneDbContext db = null;
        public CustomerDAO()
        {
            db = new WebPhoneDbContext();
        }
        public int Insert(Customer customer)
        {
            db.Customer.Add(customer);
            db.SaveChanges();
            return customer.Customer_id;
        }
    }
}
