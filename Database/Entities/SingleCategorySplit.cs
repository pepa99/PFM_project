using System.ComponentModel.DataAnnotations;

namespace PFM_project.Commands
{
    public class SingleCategorySplit
    {
        [Required]
        public string catcode{get;set;}
        [Required]
        public double amount{get;set;}
    }
}