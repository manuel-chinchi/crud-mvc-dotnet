using crud.Data;
using crud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Services
{
    public class ArticleService : IArticleService
    {
        public ArticleService() { }

        public List<Article> GetArticles()
        {
            using (var db = new ApplicationContext())
            {
                return db.Articles.Include(a => a.Category).ToList();
            }
        }

        public Article GetArticle(int id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Articles.Include(a => a.Category).Where(a => a.Id == id).FirstOrDefault();
            }
        }

        public void CreateArticle(Article article)
        {
            using (var db = new ApplicationContext())
            {
                db.Articles.Add(new Article()
                {
                    Name = article.Name,
                    Description = article.Description,
                    CategoryId = article.CategoryId,
                    Quantity = article.Quantity,
                    DateCreated = DateTime.Now
                });

                db.SaveChanges();
            }
        }

        public void UpdateArticle(Article article)
        {
            using (var db = new ApplicationContext())
            {
                article.DateUpdated = DateTime.Now;
                db.Articles.Update(article);
                db.SaveChanges();
            }
        }

        public void DeleteArticle(int id)
        {
            using (var db = new ApplicationContext())
            {
                var article = this.GetArticle(id);

                if (article != null)
                {
                    article.DateUpdated = DateTime.Now;
                    db.Articles.Remove(article);
                    db.SaveChanges();
                }
            }
        }
    }
}
