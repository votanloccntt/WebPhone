using Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CommentDAO
    {
        WebPhoneDbContext db = null;
        public CommentDAO()
        {
            db = new WebPhoneDbContext();
        }
        public long Insert(Comment entity)
        {
            entity.Comment_time = DateTime.Now;
            db.Comment.Add(entity);
            db.SaveChanges();
            return entity.Comment_id;
        }
        public IEnumerable<Comment> ListAllPaging(string sreachString, int page, int pageSize)
        {
            IQueryable<Comment> model = db.Comment;
            if (!string.IsNullOrEmpty(sreachString))
            {
                model = model.Where(x => x.Full_name.Contains(sreachString) || x.Comment_content.Contains(sreachString)
                );
            }
            return model.OrderBy(x => x.Comment_id).ToPagedList(page, pageSize);
        }
        public int CountComment()
        {
            var commnets = db.Comment.ToList();
            return commnets.Count();
        }
    }
}
