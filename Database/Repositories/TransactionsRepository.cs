using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFM_project.Database.Entities;
using PFM_project.Mappings;
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

        public async Task<PagedSortedList<TransactionWithSplits>> List(TransactionKind kind,DateTime start, DateTime end, int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
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
                    case "date":
                          query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.date) : query.OrderByDescending(x => x.date);
                          break;
                    case "kind":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.TransactionKind) : query.OrderByDescending(x => x.TransactionKind);
                        break;     
                    
                }
            } 
            else
            {
                query = query.OrderBy(p => p.id);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var items = await query.ToListAsync();
            var solution=new List<TransactionWithSplits>();
            foreach(var elem in items)
            { 
              TransactionWithSplits transactionWithSplits=new TransactionWithSplits();
              transactionWithSplits.id=elem.id;
              transactionWithSplits.beneficiaryname=elem.beneficiaryname;
              transactionWithSplits.date=elem.date;
              transactionWithSplits.catcode=elem.catcode;
              transactionWithSplits.currency=elem.currency;
              transactionWithSplits.amount=elem.amount; 
              transactionWithSplits.TransactionKind=elem.TransactionKind;
              transactionWithSplits.Directions=elem.Directions;
              transactionWithSplits.mcc=elem.mcc;
              transactionWithSplits.description=elem.description;
              transactionWithSplits.catcode=elem.catcode;
              var splits=new List<SingleCategorySplit>();  
              var query1=await _context.TransactionCategoryMappings.Where(p=>p.TransactionID==elem.id).AsQueryable().ToListAsync();
              foreach(var elem1 in query1)
              {
               splits.Add(new SingleCategorySplit(elem1.CategoryId,elem1.amount)); 
              }
              transactionWithSplits.list=splits;
              solution.Add(transactionWithSplits);
            }

            return new PagedSortedList<TransactionWithSplits>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = solution,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
        }

        public async Task<SpendingInCategory> GetByCat(string catcode, DateTime start, DateTime end, Directions direction)
        {
            var query = _context.Transactions.Where(p => p.catcode == catcode && start<=p.date && p.date<=end && p.Directions==direction).AsQueryable();
            int total=query.Count();
            var items=await query.ToListAsync();
            double amount=0;
            foreach(var elem in items)
            {
                amount+=elem.amount;
            }
            SpendingInCategory result=new SpendingInCategory();
            result.catcode=catcode;
            result.amount=amount;
            result.count=total;
            return result;
        }

        public async Task<TransactionCategoryMapping> CreateSplit(TransactionCategoryMapping junction)
        {
           
            await _context.TransactionCategoryMappings.AddAsync(junction);
             await _context.SaveChangesAsync();
             return junction;
        }
        public async Task<List<TransactionCategoryMapping>> RemoveSplit(string id)
        {
           var result=new List<TransactionCategoryMapping>(); 
           var lista= _context.TransactionCategoryMappings.Where(p=>p.TransactionID==id).AsQueryable().ToList();
           foreach(var elem in lista)
           {
            result.Add(elem);
             _context.TransactionCategoryMappings.Remove(elem);

           }
           await _context.SaveChangesAsync();
           return result;
        }

        public async Task AutoCategorize()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Instructor\Desktop\PFM-project\PFM_project\Rules.txt");
            
            int n=Convert.ToInt32(lines.Length/4);
            for(int i=0;i<n;i++)
            {
             string code=lines[i*4+2].Split(":")[1];
             string query=lines[i*4+3].Split(":")[1];   
             var result=_context.Database.ExecuteSqlRaw("UPDATE public.transactions \r\n"+ "SET catcode="+code+"\r\n"+query+" AND catcode is null"+";");
             await _context.SaveChangesAsync();
            }
        }

        public async Task MLCategorize()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Instructor\Desktop\PFM-project\PFM_project\ml.txt");
            int n=lines.Length;
            for(int i=0;i<n;i++)
            {
                string code=lines[i].Split(":")[1];
                string id=lines[i].Split(":")[0];
                string command="UPDATE public.transactions \r\n"+"SET catcode="+code+"\r\n"+"WHERE id='"+id+"'";
                
                _context.Database.ExecuteSqlRaw(command);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<float> ValidateAccuracy(List<string> ind, List<string> code)
        {
            int n=ind.Count();
            int sum=0;
            for(int i=0;i<n;i++)
            {
                var tran=await _context.Transactions.FirstOrDefaultAsync(p=>p.id==ind[i]);
                var code_db=tran.catcode;
                if(code_db==code[i])
                {
                    sum+=1;
                }
            }
            return (100*sum/n);
        }
    }
}