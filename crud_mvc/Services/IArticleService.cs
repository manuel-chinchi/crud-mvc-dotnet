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

        public bool UpdateArticle(Article article);

        public bool DeleteArticle(int id);
    }
}
