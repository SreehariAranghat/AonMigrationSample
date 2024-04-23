using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    /// <summary>
    /// Single Entry of Book in the libray
    /// </summary>
    /// <remarks>
    /// Multiple copies of the book may be tagged with
    /// diffrent id.
    /// </remarks>
    public class Book : BaseObject
    {
        [Required]
        ///<summary>
        /// Book Name 
        /// </summary>
        public string Name { get; set; }

        [Required]
        ///<summary>
        ///Book Title
        /// </summary>
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
