using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDto
{
    public class ContryDto
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32)]
        [Required]
        public string Name { get; set; }
        [MaxLength(4)]
        public string PhoneCode { get; set; }
    }
}
