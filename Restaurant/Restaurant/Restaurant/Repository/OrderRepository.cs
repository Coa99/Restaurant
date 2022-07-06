using Restaurant.Model;

namespace Restaurant.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DatabaseContext _dbContext;

        public OrderRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}