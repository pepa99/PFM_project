using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFM_project.Database.Entities
{
    public class TransactionCategoryMapping
    {
    public TransactionCategoryMapping()
    {
        vreme=DateTime.Now;
    }    
    public string TransactionID { get; set; }
    public string CategoryId { get; set; }

    public virtual TransactionsEntity Transaction {get;set;}
    public virtual CategoryEntity Category {get;set;}

    public double amount {get;set;}
    public DateTime vreme{get;set;}
    }
}