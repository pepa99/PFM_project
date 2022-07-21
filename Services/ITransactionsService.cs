using PFM_project.Command;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Services
{
   public interface ITransactionsService
   {
     Task<PagedSortedList<Models.Transaction>> GetProducts(TransactionKind kind, DateOnly start, DateOnly end, int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
   
    Task<Models.Transaction> CreateTransactions(CreateTransactionsCommand command);
   }

}