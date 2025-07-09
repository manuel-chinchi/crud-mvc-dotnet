using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc_aspnet_core.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        // Foreign key
        public int CategoryId { get; set; }

        // Navigation properties
        public virtual Category Category { get; set; }

        public Article() { DateCreated = DateTime.UtcNow; DateUpdated = null; }
    }
}
