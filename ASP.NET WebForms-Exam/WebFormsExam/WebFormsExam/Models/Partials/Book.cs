using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFormsExam.Models
{
    [MetadataType(typeof(BookMetadata))]
    public partial class Book
    {
    }

    public class BookMetadata
    {
        [Required, MaxLength(150)]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(50)]
        public string ISBN { get; set; }

        [MaxLength(300)]
        public string WebSite { get; set; }
    }
}