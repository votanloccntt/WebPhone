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
        public Order_detail ViewDetail(int id)
        {
            return db.Order_detail.Find(id);
        }
        public bool ViewOrder(Order_detail entity)
        {
            var order_detail = db.Order_detail.Find(entity.Order_id);
            order_detail.Order.Customer.Customer_name = entity.Order.Customer.Customer_name;
            order_detail.Order.Customer.Customer_phone = entity.Order.Customer.Customer_phone;
            order_detail.Order.Customer.Customer_mail = entity.Order.Customer.Customer_mail;
            order_detail.Order.Delivery_address = entity.Order.Delivery_address;
            order_detail.Phones.Name_phone = entity.Phones.Name_phone;
            order_detail.Sale_quantity = entity.Sale_quantity;
            order_detail.Price = entity.Price;
            order_detail.Order.Total_price = entity.Order.Total_price;
            db.SaveChanges();
            return true;
        }

    }
}