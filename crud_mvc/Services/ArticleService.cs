using crud_mvc.Data;
using crud_mvc.Models;
using Microsoft.EntityFrameworkCore;
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
                #region NUEVO: Recupera las relaciones con la tabla "categories"
                var articles = db.Articles.Include(a => a.Category).ToList();
                return articles;
                #endregion
            }
        }

        public Article GetArticle(int id)
        {
            using (var db = new AppDbContext())
            {
                #region NUEVO: Recupera las relaciones con la tabla "categories"
                return db.Articles.Include(a => a.Category).Where(a => a.Id == id).FirstOrDefault();
                #endregion
            }
        }

        public void InsertArticle(Article article)
        {
            using (var db = new AppDbContext())
            {
                #region NUEVO: Agrega solamente la entidad de tipo Article
                db.Articles.Add(new Article()
                {
                    Name = article.Name,
                    Description = article.Description,
                    CategoryId = article.CategoryId,
                    Quantity = article.Quantity
                });
                db.SaveChanges();
                #endregion
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
            return string.IsNullOrEmpty(article.Name) || article.Category == null || string.IsNullOrEmpty(article.Description) ? false : true;
        }
    }
}
