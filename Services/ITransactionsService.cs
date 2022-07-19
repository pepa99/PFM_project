using PFM_project.Command;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Services
{
   public interface ITransactionsService
   {
     Task<PagedSortedList<Models.Transactions>> GetProducts(TransactionKind kind, int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
   
    Task<Models.Transactions> CreateTransactions(CreateTransactionsCommand command);
   }

}