using AutoMapper;
using PFM_project.Command;
using PFM_project.Database.Entities;
using PFM_project.Database.Repositories;
using PFM_project.Models;

namespace PFM_project.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IMapper _mapper;
        public TransactionsService(ITransactionsRepository transactionsRepository, IMapper mapper)
        {
            _transactionsRepository = transactionsRepository;
            _mapper = mapper;
        }
        public async Task<Transactions> CreateTransactions(CreateTransactionsCommand command)
        {
            var entity = _mapper.Map<TransactionsEntity>(command);

            var existingProduct = await _transactionsRepository.Get(command.id);
            if (existingProduct != null)
            {
                return null;
            }
            var result = await _transactionsRepository.Create(entity);

            return _mapper.Map<Models.Transactions>(result);
        }

        public async Task<PagedSortedList<Models.Transactions>> GetProducts(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
           var result = await _transactionsRepository.List(page, pageSize, sortBy, sortOrder);

            return _mapper.Map<PagedSortedList<Models.Transactions>>(result);        }
    }
}