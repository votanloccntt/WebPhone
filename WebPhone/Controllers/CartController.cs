using Models.DAO;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPhone.Models;

namespace WebPhone.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Phones.Phones_id == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new PhonesDAO().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Phones.Phones_id == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Phones.Phones_id == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Phones = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }

            }
            else
            {
                var item = new CartItem();
                item.Phones = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string cusname, string cusphone, string cusaddress, string cusemail)
        {
            var cart = (List<CartItem>)Session[CartSession];
            var customer = new Customer();
            var order = new Order();
            foreach(var item in cart)
            {
                if(item.Phones.Promotion_price==null)
                {
                    order.Total_price = item.Phones.Price * item.Quantity;
                }
                else
                {
                    order.Total_price = item.Phones.Promotion_price * item.Quantity;
                }
            }    
            order.Create_date = DateTime.Now;
            order.Delivery_address = cusaddress;
            customer.Customer_phone = cusphone;
            customer.Customer_name = cusname;
            customer.Customer_mail = cusemail;
            var customerid = new CustomerDAO().Insert(customer);
            order.Customer_id = customer.Customer_id;
            var id = new OrderDAO().Insert(order);          
            var detailDAO = new OrderDetailDAO();
            foreach (var item in cart)
            {             
                var orderDetail = new Order_detail();
                orderDetail.Phones_id = item.Phones.Phones_id;
                orderDetail.Order_id = id;
                if(item.Phones.Promotion_price==null)
                {
                    orderDetail.Price = item.Phones.Price;
                }
                else
                {
                    orderDetail.Price = item.Phones.Promotion_price;
                }                
                orderDetail.Sale_quantity = item.Quantity;
                detailDAO.Insert(orderDetail);
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}