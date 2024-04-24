using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class User : BaseObject
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public Address Address { get; set; }

    }

    public class Address
    {
        [Key]
        public int Id { get; set; } 

        public string Address1 { get; set; }
        public string PinCode { get; set; }
    }
  
}
