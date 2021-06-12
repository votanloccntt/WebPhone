using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class PhonesDAO
    {
        WebPhoneDbContext db = null;
        public PhonesDAO()
        {
            db = new WebPhoneDbContext();
        }
        public List<Phones>ListNewProduct(int top)
        {
            return db.Phones.OrderByDescending(x => x.Create_date).Take(top).ToList();
        }
        public List<Phones> ListPromotionProduct(int top)
        {
            return db.Phones.OrderByDescending(x => x.Promotion_price).Take(top).ToList();
        }
        public List<Phones> ListRelatedProduct(int productId)
        {
            var product = db.Phones.Find(productId);
            return db.Phones.Where(x => x.Phones_id != productId && x.Category_id == product.Category_id).ToList();          
        }
        public List<Phones> ListByCategoryId(int categoryID)
        {
            return db.Phones.Where(x => x.Category_id == categoryID).ToList();
        }
        public IEnumerable<Phones> ListAllPaging(string sreachString, int page, int pageSize)
        {
            IQueryable<Phones> model = db.Phones;
            if (!string.IsNullOrEmpty(sreachString))
            {
                model = model.Where(x => x.Name_phone.Contains(sreachString) || x.Screen.Contains(sreachString) || x.Operating_system.Contains(sreachString)
                || x.Rear_camera.Contains(sreachString) || x.Front_camera.Contains(sreachString) || x.Chip.Contains(sreachString) || x.Ram.Contains(sreachString)
                || x.Internal_memory.Contains(sreachString) || x.Sim.Contains(sreachString) || x.Pin.Contains(sreachString) || x.Charger.Contains(sreachString)
                );
            }
            return model.OrderBy(x => x.Phones_id).ToPagedList(page, pageSize);
        }
        public int Insert(Phones entity)
        {
            db.Phones.Add(entity);
            db.SaveChanges();
            return entity.Phones_id;
        }
        public bool Update(Phones entity)
        {
            var phones = db.Phones.Find(entity.Phones_id);
            phones.Name_phone = entity.Name_phone;
            phones.Image = entity.Image;
            phones.Price = entity.Price;
            phones.Quantity = entity.Quantity;
            phones.Screen = entity.Screen;
            phones.Operating_system = entity.Operating_system;
            phones.Rear_camera = entity.Rear_camera;
            phones.Front_camera = entity.Front_camera;
            phones.Chip = entity.Chip;
            phones.Ram = entity.Ram;
            phones.Internal_memory = entity.Internal_memory;
            phones.Sim = entity.Sim;
            phones.Pin = entity.Pin;
            phones.Charger = entity.Charger;
            phones.Promotion_price = entity.Promotion_price;
            phones.Start_promotion = entity.Start_promotion;
            phones.End_promotion = entity.End_promotion;
            db.SaveChanges();
            return true;
        }
        public Phones GetById(string namePhone)
        {
            return db.Phones.SingleOrDefault(x => x.Name_phone == namePhone);
        }
        public Phones ViewDetail(int id)
        {
            return db.Phones.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var phones = db.Phones.Find(id);
                db.Phones.Remove(phones);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
