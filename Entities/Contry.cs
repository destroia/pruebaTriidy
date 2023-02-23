using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contry
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32)]
        [Required]
        public string Name { get; set; }
        [MaxLength(4)]
        public string PhoneCode { get; set; }
       public List<City> Cities { get; set; }
    }
}
