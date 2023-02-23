using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ContryId { get; set; }
        [MaxLength(32)]
        [Required]
        public string Name { get; set; }
    }
}
