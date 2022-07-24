using System.Runtime.Serialization;

namespace PFM_project.Database.Entities
{
    public enum TransactionKind
    {
       [EnumMember(Value = "dep")]
       dep = 0,
       [EnumMember(Value = "wdw")]
       wdw = 1,
       [EnumMember(Value = "pmt")]
       pmt = 2, 
       [EnumMember(Value = "fee")]

       fee = 3, 
       [EnumMember(Value = "inc")]

       inc = 4, 
       [EnumMember(Value = "rev")]

       rev = 5, 
       [EnumMember(Value = "adj")]

       adj = 6, 
       [EnumMember(Value = "lnd")]
      
       lnd = 7, 
       [EnumMember(Value = "lnr")]
      
       lnr = 8, 
       [EnumMember(Value = "fcx")]

       fcx = 9, 
       [EnumMember(Value = "aop")]

       aop = 10, 
       [EnumMember(Value = "acl")]

       acl = 11, 
       [EnumMember(Value = "spl")]

       spl = 12, 
       [EnumMember(Value = "sal")]
      
       sal = 13
    }
}