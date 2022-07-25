using System.ComponentModel.DataAnnotations.Schema;

namespace PFM_project.Database.Entities
{
    public class CategoryEntity
    {
        public string code {get;set;}
        public string name{get;set;}
        public string parent_code{get;set;}
        [NotMapped]
        public virtual ICollection<TransactionCategoryMapping> TransactionCategoryMappings{get;set;}
    }
}