using System.ComponentModel.DataAnnotations;

namespace PFM_project.Database.Entities
{
    public class SingleCategorySplit
    {
        public SingleCategorySplit(string catcode, double amount)
        {
            this.catcode=catcode;
            this.amount=amount;

        }

        [Required]
        public string catcode{get;set;}
        [Required]
        public double amount{get;set;}
    }
}