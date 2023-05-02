using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorial_20024.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }

        // Navigation Properties
        // Make sure to add Virtual, or else you will get issues later.
        public virtual Blog Blog { get; set; }

    }
}
