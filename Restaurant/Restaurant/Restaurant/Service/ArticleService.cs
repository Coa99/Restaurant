using System.Collections.Generic;
using AutoMapper;
using Restaurant.Model;
using Restaurant.Repository;

namespace Restaurant.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
        }

        public Article Create(Article article)
        {
            return _articleRepository.Insert(article);
        }

        public IEnumerable<Article> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public Article GetById(int id)
        {
            return _articleRepository.GetById(id);
        }
    }
}