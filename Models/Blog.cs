using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorial_20024.Models
{
    public class Blog
    {

        public int BlogId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }


        // Navigation Property.
        public virtual List<Post> Posts { get; set; }
    }
}
