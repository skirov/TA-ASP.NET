using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public interface IUowData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
