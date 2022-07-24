using PFM_project.Commands;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Services
{
   public interface ITransactionsService
   {
     Task<PagedSortedList<Models.Transaction>> GetProducts(TransactionKind kind, DateTime start, DateTime end, int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
   
    Task<Models.Transaction> CreateTransactions(CreateTransactionsCommand command);
    Task<TransactionsEntity> GetTransaction(string id);
    Task<TransactionsEntity> Update(TransactionsEntity entity);
   }

}