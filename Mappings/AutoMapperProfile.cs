using AutoMapper;
using PFM_project.Commands;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryEntity, Category>()
                .ForMember(d => d.code, opts => opts.MapFrom(s => s.code));
            CreateMap<TransactionsEntity, PFM_project.Models.Transaction>()
                .ForMember(d => d.id, opts => opts.MapFrom(s => s.id));

            CreateMap<PagedSortedList<TransactionsEntity>, PagedSortedList<PFM_project.Models.Transaction>>();
            
            CreateMap<CreateTransactionsCommand, TransactionsEntity>()
                .ForMember(d => d.id, opts => opts.MapFrom(s => s.id));
            CreateMap<CategoryCsv,CategoryEntity>()
                .ForMember(d => d.code, opts => opts.MapFrom(s => s.code));
            
        }
    }
}