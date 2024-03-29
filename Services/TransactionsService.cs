using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PFM_project.Commands;
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

        public async Task AutoCategorize()
        {
            await _transactionsRepository.AutoCategorize();
        }

        public async Task<Transaction> CreateTransactions(CreateTransactionsCommand command)
        {
            var entity = _mapper.Map<TransactionsEntity>(command);

            var existingProduct = await _transactionsRepository.Get(command.id);
            if (existingProduct != null)
            {
                return null;
            }
            var result = await _transactionsRepository.Create(entity);

            return _mapper.Map<Models.Transaction>(result);
        }

        public async Task<PagedSortedList<TransactionWithSplits>> GetProducts(TransactionKind kind,DateTime start, DateTime end, int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
           var result = await _transactionsRepository.List(kind,start, end,page, pageSize, sortBy, sortOrder);

            return result;        }
        public async Task<TransactionsEntity> GetTransaction(string id)
        {
            var result =await _transactionsRepository.Get(id);
            return result;
        }
        public async Task<SpendingInCategory> GetTransactionsByCat(string catcode,DateTime start, DateTime end, Directions direction)
        {
            return await _transactionsRepository.GetByCat(catcode,start,end,direction);

        }

        public async Task MLCategorize()
        {
            await _transactionsRepository.MLCategorize();
        }

        public async Task<List<TransactionCategoryMapping>> RemoveSplit(string id)
        {
            return await _transactionsRepository.RemoveSplit(id);
        }

        public async Task<TransactionCategoryMapping> split(TransactionCategoryMapping junction)
        {
           return await  _transactionsRepository.CreateSplit(junction);
        }

        public async Task<TransactionsEntity> Update(TransactionsEntity entity)
        {
            return await _transactionsRepository.Update(entity);
        }

        public async Task<float> ValidateAccuracy(List<string> ind, List<string> code)
        {
            return await _transactionsRepository.ValidateAccuracy(ind,code);
        }
    }
}