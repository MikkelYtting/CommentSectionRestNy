using CommentSection;
using System.Collections.Generic;


namespace CommentSectionWeb.Manager
{
    public interface ICommentsManager
    {
        IEnumerable<Comment> GetAll(string Commenttext = null);
        Comment GetById(int id);
        public Comment Add(Comment comment);
        public Comment Update(int id, Comment updates);
        public Comment Delete(int id);

    }
}
