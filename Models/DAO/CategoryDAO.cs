using Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategoryDAO
    {
        WebPhoneDbContext db = null;
        public CategoryDAO()
        {
            db = new WebPhoneDbContext();
        }
        public IEnumerable<Category> ListAllPaging(string sreachString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Category;
            if (!string.IsNullOrEmpty(sreachString))
            {
                model = model.Where(x => x.Category_name.Contains(sreachString)
                );
            }
            return model.OrderBy(x => x.Category_id).ToPagedList(page, pageSize);
        }
        public List<Category>ListAll()
        {
            return db.Category.OrderBy(x => x.Display_order).ToList();
        }
        public long Insert(Category entity)
        {
            db.Category.Add(entity);
            db.SaveChanges();
            return entity.Category_id;
        }
        public bool Update(Category entity)
        {
            var category = db.Category.Find(entity.Category_id);
            category.Category_name = entity.Category_name;
            category.Parent_id = entity.Parent_id;
            db.SaveChanges();
            return true;
        }
        public Category GetById(string categoryName)
        {
            return db.Category.SingleOrDefault(x => x.Category_name == categoryName);
        }
        public Category ViewDetail(int id)
        {
            return db.Category.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var category = db.Category.Find(id);
                db.Category.Remove(category);
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
