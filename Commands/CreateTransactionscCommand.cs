using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Commands
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
        [StringLength(3, MinimumLength = 3,ErrorMessage = "Currency must be 3 characters long.")]
        public string currency{get;set;}
        public MccCodeEnum mcc{get;set;}
        [Required]
        public TransactionKind? TransactionKind{get;set;}

        public string catcode{get;set;}
    }
}