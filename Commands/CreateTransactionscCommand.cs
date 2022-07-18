using System.ComponentModel.DataAnnotations;
using PFM_project.Models;

namespace PFM_project.Command
{
    public class CreateTransactionsCommand
    {
        [Required]
        public int id{get;set;}
        [Required]
        public string beneficiaryname{get;set;}
        [Required]
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