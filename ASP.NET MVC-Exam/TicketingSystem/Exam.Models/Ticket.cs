using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exam.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength=5, ErrorMessage="The title must be between 5 and 100 symbols.")]
        public string Title { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public virtual ApplicationUser User { get; set; }
        
        public string UserId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }

        [StringLength(1000, ErrorMessage = "The description must at most 1000 symbols.")]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
