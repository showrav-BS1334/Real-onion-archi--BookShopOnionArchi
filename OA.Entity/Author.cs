using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity
{
    public class Author : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
