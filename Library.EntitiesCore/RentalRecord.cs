using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class RentalRecord : BaseObject
    {
        public User User { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public Book Book { get; set; }


        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int Fine { get; set; }
    }
}
