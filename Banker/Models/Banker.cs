using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banker.Models{
    public class User:BaseEntity{

        public string fname {get; set;}

        public string lname{get; set;}

        public string email {get; set;}

        public string password {get; set;}

        public double? balance{get; set;}

        public List<Transaction> transactions {get; set;}

        public User(){
            transactions = new List<Transaction>();
        }

    }
    public class Transaction: BaseEntity{
        public double? amount{get;set;}

        public int userid {get; set;}

        public User user {get; set;}
    }
}