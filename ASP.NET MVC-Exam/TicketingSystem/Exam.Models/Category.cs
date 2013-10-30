using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Category
    {
        public Category()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "The comment between 2 and 150 symbols.")]
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
