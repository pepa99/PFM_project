namespace PFM_project.Services
{
    public interface ITransactionsService
    {
        Task<Transactions> GetTransactions();
        Task<Transactions> CreateTransactions(CreateTransactionsCommand command);
    }
}