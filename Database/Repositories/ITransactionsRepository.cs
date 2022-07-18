using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Database.Repositories
{
    public interface ITransactionsRepository
    {
        Task<TransactionsEntity> Get(string id);
        Task<TransactionsEntity> Create (TransactionsEntity entity);
        Task<PagedSortedList<TransactionsEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
    }
}