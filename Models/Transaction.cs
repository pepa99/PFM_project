using PFM_project.Database.Entities;

namespace PFM_project.Models
{
    public class Transaction
    {
        public string id{get;set;}
        public string beneficiaryname{get;set;}
        public DateTime date{get;set;}
        public Directions Directions{get;set;}  
        public double amount{get;set;}
        public string description{get;set;}
        public string currency{get;set;}
        public MccCodeEnum mcc{get;set;}
        public TransactionKind TransactionKind{get;set;}
        public string catcode;
    }
}