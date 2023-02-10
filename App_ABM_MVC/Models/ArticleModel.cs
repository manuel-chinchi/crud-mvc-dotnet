using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_ABM_MVC.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public ArticleModel() { }

        public ArticleModel(int id, string name, string description, string category)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
        }
    }
}
