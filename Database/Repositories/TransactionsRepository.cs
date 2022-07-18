using PFM_project.Database.Entities;

namespace PFM_project.Database.Repositories
{
    public class TransactionRepository : ITransactionsRepository
    {
        private readonly TranasactionsDBContext _context;
        public TransactionRepository(TranasactionsDBContext context)
        {
            _context = context;
        }
        public Task<TransactionsEntity> Create(TransactionsEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionsEntity> Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}