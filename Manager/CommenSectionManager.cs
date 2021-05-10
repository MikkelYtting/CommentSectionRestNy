using CommentSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentSectionWeb.Manager
{
    public class CommenSectionManager
    {
        private static int _nextId = 1;

        public static readonly List<Comment> CommentData = new List<Comment>
        {
            new Comment {Id = _nextId++, Commenttext = "123"}
        };

        public List<Comment> getAll()
        {
            return CommentData;
        }

        public Comment GetById(int id)
        {
            return CommentData.Find(song => song.Id == id);
        }

        public Comment Add(Comment newComment)
        {
            newComment.Id = _nextId++;
            CommentData.Add(newComment);
            return newComment;
        }

        public Comment Delete(int id)
        {
            var comment = CommentData.Find(song1 => song1.Id == id);
            if (comment == null) return null;
            CommentData.Remove(comment);
            return comment;
        }

        public Comment Update(int id, Comment updates)
        {
            var Comment = CommentData.Find(Comment1 => Comment1.Id == id);
            if (Comment == null) return null;
            Comment.Commenttext = updates.Commenttext;

            return Comment;
        }
    }
}
