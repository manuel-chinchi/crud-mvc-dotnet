using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Models
{
    public class ArticleModel
    {
        [Key]
        [Range(1, 2000)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool IsEnabled { get; set; }

        public ArticleModel() { IsEnabled = true; }

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
