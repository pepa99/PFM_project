using PFM_project.Models;

namespace PFM_project.Database.Entities
{
    public class TransactionsEntity
    {
        public int id{get;set;}
        public string beneficiaryname{get;set;}
        public string date{get;set;}
        public Directions? Directions{get;set;}  
        public double amount{get;set;}
        public string description{get;set;}
        public string currency{get;set;}
        public TransactionKind? Kind{get;set;}
        public string catcode{get;}
        public int mcc{get;set;}
    }
}