using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity
{
    public class Book : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string CoverPath { get; set; }
        public string Language { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
    }
}
