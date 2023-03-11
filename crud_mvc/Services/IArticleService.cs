using crud_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Services
{
    public interface IArticleService
    {
        public List<Article> GetArticles();

        public Article GetArticle(int id);

        public void InsertArticle(Article article);

        public void UpdateArticle(Article article);

        public void DeleteArticle(int id);
    }
}
