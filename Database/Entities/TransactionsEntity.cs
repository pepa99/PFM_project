
using System.ComponentModel.DataAnnotations.Schema;
using PFM_project.Commands;

namespace PFM_project.Database.Entities
{
    public class TransactionsEntity
    {
        public string id{get;set;}
        public string beneficiaryname{get;set;}
        public DateTime date{get;set;}
        public Directions Directions{get;set;}  
        public double amount{get;set;}
        public string description{get;set;}
        public string currency{get;set;}
        public TransactionKind TransactionKind{get;set;}
        public MccCodeEnum mcc{get;set;}
        public string catcode{get;set;}
        [ForeignKey("catcode")]
        public CategoryEntity Category{get;set;}
        [NotMapped]
        public virtual ICollection<TransactionCategoryMapping> TransactionCategoryMappings{get;set;}
    }
}