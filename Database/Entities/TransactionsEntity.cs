
namespace PFM_project.Database.Entities
{
    public class TransactionsEntity
    {
        public string id{get;set;}
        public string beneficiaryname{get;set;}
        public DateTime date{get;set;}
        public Directions? Directions{get;set;}  
        public double amount{get;set;}
        public string description{get;set;}
        public string currency{get;set;}
        public TransactionKind Kind{get;set;}
        public string catcode{get;set;}
        public int mcc{get;set;}
    }
}