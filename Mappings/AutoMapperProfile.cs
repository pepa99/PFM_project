using AutoMapper;
using PFM_project.Command;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TransactionsEntity, PFM_project.Models.Transactions>()
                .ForMember(d => d.id, opts => opts.MapFrom(s => s.id));

            CreateMap<PagedSortedList<TransactionsEntity>, PagedSortedList<PFM_project.Models.Transactions>>();
            
            CreateMap<CreateTransactionsCommand, TransactionsEntity>()
                .ForMember(d => d.id, opts => opts.MapFrom(s => s.id));
        }
    }
}