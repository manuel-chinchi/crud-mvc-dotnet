using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public bool IsEnabled { get; set; }

        public ArticleModel() { }

        public ArticleModel(int id, string name, string description, string category, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Quantity = quantity;
            IsEnabled = true;
        }

        public override bool Equals(object article)
        {
            if ((article == null) || !this.GetType().Equals(article.GetType()))
            {
                return false;
            }
            else
            {
                ArticleModel p = (ArticleModel)article;
                return (Id == p.Id) && (Name == p.Name) && (Category == p.Category) && (Description == p.Description) && (Quantity == p.Quantity);
            }
        }
    }
}
