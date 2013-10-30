using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Exam.Web.Models
{
    public class CommentDisplayModel
    {
        public string Username { get; set; }

        public string Content { get; set; }

        public static Expression<Func<Comment, CommentDisplayModel>> FromComment
        {
            get
            {
                return comment => new CommentDisplayModel()
                {
                    Content = comment.Content,
                    Username = comment.User.UserName
                };
            }
        }
    }
}
