using Microsoft.AspNetCore.Mvc;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Database.Repositories
{
    public interface ITransactionsRepository
    {
        Task<TransactionsEntity> Get(string id);
        Task<TransactionsEntity> Update(TransactionsEntity entity);
        Task<TransactionsEntity> Create (TransactionsEntity entity);
        Task<PagedSortedList<TransactionWithSplits>> List(TransactionKind kind, DateTime start, DateTime end, int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
        Task<SpendingInCategory> GetByCat(string catcode, DateTime start, DateTime end, Directions direction);
        Task<TransactionCategoryMapping> CreateSplit(TransactionCategoryMapping junction);
        Task AutoCategorize();
        Task<List<TransactionCategoryMapping>> RemoveSplit(string id);
        Task MLCategorize();
        Task<float> ValidateAccuracy(List<string> ind, List<string> code);
    }
}