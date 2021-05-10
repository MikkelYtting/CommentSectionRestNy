using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentSectionWeb.Model
{
    public class CommentException : Exception
    {
        public CommentException(string message) : base(message)
        {

        }
    }
}
