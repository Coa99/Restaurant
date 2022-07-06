
using Restaurant.Model;

namespace Restaurant.Repository
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly DatabaseContext _dbContext;

        public ArticleRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}