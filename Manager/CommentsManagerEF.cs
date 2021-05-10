using CommentSection;
using CommentSectionWeb.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentSectionWeb.Manager
{
    public class CommentsManagerEF
    {
        private readonly CommentContext _context;

        public CommentsManagerEF(CommentContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetAll(string Commenttext = null)
        // https://www.moesif.com/blog/technical/api-design/REST-API-Design-Filtering-Sorting-and-Pagination/
        {
            IQueryable<Comment> selectStatement = _context.Comments;
            // https://www.tutorialspoint.com/what-is-the-difference-between-ienumerable-and-iqueryable-in-chash
            if (Commenttext != null && Commenttext.Trim().Length > 0)
            {
                selectStatement = selectStatement.Where(car => car.Commenttext.StartsWith(Commenttext));
            }

            return selectStatement;
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public Comment Add(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges(); // don't forget to save
                // car.Id us updated by the database: id int identity(1,1)
                return comment;
            }
            catch (DbUpdateException ex)
            {
                _context.Comments.Remove(comment);
                // exception translation
                throw new CommentException(ex.InnerException.Message);
            }
        }

        public Comment Update(int id, Comment updates)
        {
            try
            {
                Comment comment = _context.Comments.Find(id);
                if (comment == null) return null;
                comment.Commenttext = updates.Commenttext;
                _context.Entry(comment).State = EntityState.Modified;
                _context.SaveChanges();
                return comment;
            }
            catch (DbUpdateException ex)
            {
                throw new CommentException(updates.Commenttext + "\n" + ex.InnerException.Message);
            }
        }

        public Comment Delete(int id)
        {
            Comment comment = _context.Comments.Find(id);
            if (comment == null) return null;
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return comment;
        }
    }
}
