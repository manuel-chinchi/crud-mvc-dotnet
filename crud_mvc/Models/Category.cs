using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        // Navigation properties
        public virtual ICollection<Article> Articles { get; set; }

        public Category() { IsEnabled = true; DateCreated = DateTime.Now; DateUpdated = null; }
    }
}
