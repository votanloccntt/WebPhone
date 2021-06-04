using Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDAO
    {
        WebPhoneDbContext db = null;
        public OrderDAO()
        {
            db = new WebPhoneDbContext();
        }
        public int Insert(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
            return order.Order_id;
        }
        public IEnumerable<Order> ListAllPaging(string sreachString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Order;
            if (!string.IsNullOrEmpty(sreachString))
            {
                model = model.Where(x => x.Customer.Customer_name.Contains(sreachString) || x.Delivery_address.Contains(sreachString)
            );
            }
            return model.OrderBy(x => x.Order_id).ToPagedList(page, pageSize);
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
