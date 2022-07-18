namespace PFM_project.Models
{
    public class Transactions
    {
        public int id{get;set;}
        public string beneficiaryname{get;set;}
        public string date{get;set;}
        public Directions Directions{get;set;}  
        public double amount{get;set;}
        public string description{get;set;}
        public string currency{get;set;}
        public TransactionKind 
    }
}