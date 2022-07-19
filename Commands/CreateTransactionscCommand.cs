using System.ComponentModel.DataAnnotations;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Command
{
    public class CreateTransactionsCommand
    {
        [Required]
        public string id{get;set;}
        
        public string beneficiaryname{get;set;}
        [Required]
        public DateTime date{get;set;}
        [Required]
        public Directions? Directions{get;set;}  
        [Required]
        public double amount{get;set;}
        public string description{get;set;}
        [Required]
        public string currency{get;set;}
        [Required]
        public TransactionKind TransactionKind{get;set;}
        public string catcode{get;}
        public int mcc{get;set;}
    }
}