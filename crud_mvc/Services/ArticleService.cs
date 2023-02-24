using crud_mvc.Data;
using crud_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Services
{
    public class ArticleService
    {
        public ArticleService() { }

        public List<Article> GetArticles()
        {
            using (var db = new AppDbContext())
            {
                return db.Articles.ToList();
            }
        }

        public Article GetArticle(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Articles.Where(a => a.Id == id).FirstOrDefault();
            }
        }

        public void InsertArticle(Article article)
        {
            using (var db = new AppDbContext())
            {
                db.Articles.Add(article);
                db.SaveChanges();
            }
        }

        public bool UpdateArticle(Article article)
        {
            int countRows = 0;

            using (var db = new AppDbContext())
            {
                db.Articles.Update(article);
                countRows = db.SaveChanges();
            }

            return countRows > 0 ? true : false;
        }

        public bool DeleteArticle(int id)
        {
            using (var db = new AppDbContext())
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

        public bool IsValidArticle(Article article)
        {
            return string.IsNullOrEmpty(article.Name) || string.IsNullOrEmpty(article.Category) || string.IsNullOrEmpty(article.Description) ? false : true;
        }
    }
}
