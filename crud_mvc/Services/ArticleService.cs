using crud_mvc.Data;
using crud_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Services
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

        public void InsertArticle(Article article)
        {
            using (var db = new ApplicationContext())
            {
                db.Articles.Add(new Article()
                {
                    Name = article.Name,
                    Description = article.Description,
                    CategoryId = article.CategoryId,
                    Quantity = article.Quantity
                });
                db.SaveChanges();
            }
        }

        public bool UpdateArticle(Article article)
        {
            int countRows = 0;

            using (var db = new ApplicationContext())
            {
                db.Articles.Update(article);
                countRows = db.SaveChanges();
            }

            return countRows > 0 ? true : false;
        }

        public bool DeleteArticle(int id)
        {
            using (var db = new ApplicationContext())
            {
                var article = this.GetArticle(id);

                if (article != null)
                {
                    db.Articles.Remove(article);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}
