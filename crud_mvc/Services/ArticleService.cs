using crud_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Services
{
    public class ArticleService
    {
        public static List<ArticleModel> s_articles { get; set; }

        public ArticleService()
        {
            s_articles = new List<ArticleModel>()
            {
                new ArticleModel { Id = 1, Name = "Escoba", Category = "Otro", Description = "Chica - 130cm x 4cm", Quantity = 20 },
                new ArticleModel { Id = 2, Name = "Balde", Category = "Otro", Description = "20cm x 22cm" , Quantity = 20},
                new ArticleModel { Id = 3, Name = "Consola juegos", Category = "Otro", Description = "Play 2 - usada", Quantity = 10 }
            };
        }

        public List<ArticleModel> GetArticles()
        {
            return s_articles;
        }

        public ArticleModel GetArticle(int id)
        {
            return s_articles.Find(a => a.Id == id);
        }

        public void InsertArticle(ArticleModel article)
        {
            article.Id = s_articles.Count + 1;
            s_articles.Add(article);
        }

        public bool UpdateArticle(ArticleModel article)
        {
            ArticleModel articleChoose = this.GetArticle(article.Id);

            if (articleChoose.Equals(article) == true)
            {
                return false;
            }
            else
            {
                int articleChooseIndex = s_articles.FindIndex(a => a.Id == article.Id);
                s_articles[articleChooseIndex] = article;
                return true;
            }
        }

        public bool DeleteArticle(int id)
        {
            var article = this.GetArticle(id);
            return s_articles.Remove(article);
        }

        public bool IsValidArticle(ArticleModel article)
        {
            return string.IsNullOrEmpty(article.Name) || string.IsNullOrEmpty(article.Category) || string.IsNullOrEmpty(article.Description) ? false : true;
        }
    }
}
