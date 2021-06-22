using Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DelivererDAO
    {
        WebPhoneDbContext db = null;
        public DelivererDAO()
        {
            db = new WebPhoneDbContext();
        }
        public IEnumerable<Deliverer> ListAllPaging(string sreachString, int page, int pageSize)
        {
            IQueryable<Deliverer> model = db.Deliverer;
            if (!string.IsNullOrEmpty(sreachString))
            {
                model = model.Where(x => x.Deliverer_name.Contains(sreachString));
            }
            return model.OrderBy(x => x.Deliverer_id).ToPagedList(page, pageSize);
        }
        public List<Deliverer> ListAll()
        {
            return db.Deliverer.OrderBy(x => x.Deliverer_id).ToList();
        }
        public long Insert(Deliverer entity)
        {
            db.Deliverer.Add(entity);
            db.SaveChanges();
            return entity.Deliverer_id;
        }
        public bool Update(Deliverer entity)
        {
            var deliverer = db.Deliverer.Find(entity.Deliverer_id);
            deliverer.Deliverer_name = entity.Deliverer_name;
            deliverer.Deliverer_phone = entity.Deliverer_phone;
            db.SaveChanges();
            return true;
        }
        public Deliverer GetById(string delivererName)
        {
            return db.Deliverer.SingleOrDefault(x => x.Deliverer_name == delivererName);
        }
        public Deliverer ViewDetail(int id)
        {
            return db.Deliverer.Find(id);
        }
        public bool Delete(int id)
        {
            var deliverer = db.Deliverer.Find(id);
            db.Deliverer.Remove(deliverer);
            db.SaveChanges();
            return true;
        }
    }
}