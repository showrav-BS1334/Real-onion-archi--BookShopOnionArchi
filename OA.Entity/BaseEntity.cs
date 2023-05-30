using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
