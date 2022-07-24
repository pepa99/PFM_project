using Microsoft.EntityFrameworkCore;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Database.Repositories
{
    public class TransactionRepository : ITransactionsRepository
    {
        private readonly TranasactionsDBContext _context;
        public TransactionRepository(TranasactionsDBContext context)
        {
            _context = context;
        }
        public async Task<TransactionsEntity> Create(TransactionsEntity product)
        {
           _context.Transactions.Add(product);

            await _context.SaveChangesAsync();

            return product;        
        }
        public async Task<TransactionsEntity> Update(TransactionsEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TransactionsEntity> Get(string id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<PagedSortedList<TransactionsEntity>> List(TransactionKind kind,DateTime start, DateTime end, int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
            var query = _context.Transactions.Where(p => p.TransactionKind == kind && start<=p.date && p.date<=end).AsQueryable();

            var totalCount = query.Count();

            var totalPages = (int)Math.Ceiling(totalCount * 1.0 / pageSize);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    default:
                    case "id":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.id) : query.OrderByDescending(x => x.id);
                        break;
                    
                }
            } 
            else
            {
                query = query.OrderBy(p => p.id);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            return new PagedSortedList<TransactionsEntity>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = items,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
        }
    }
}