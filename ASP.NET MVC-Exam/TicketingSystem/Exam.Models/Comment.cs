using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        [StringLength(500, MinimumLength=3, ErrorMessage = "The comment between 3 and 500 symbols.")]
        public string Content { get; set; }
    }
}
