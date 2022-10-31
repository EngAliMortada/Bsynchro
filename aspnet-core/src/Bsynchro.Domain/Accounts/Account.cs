using Bsynchro.Customers;
using Bsynchro.Transactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bsynchro.Accounts
{
    public class Account : FullAuditedAggregateRoot<long>
    {
        #region properties
        public AccountType AccountType { get; private set; }
        public int CustomerId { get; private set; }
        public ulong Balance { get; private set; }
        public virtual Customer Customer { get; private set; }
        public virtual ICollection<Transaction> Transactions { get; private set; }

        //may add currency type property later
        #endregion


        protected Account()
        {

        }

        private Account (AccountType accountType, int customerId, ulong balance)
        {
            AccountType = accountType;
            CustomerId = customerId;
            Balance = balance;
        }

        public static Account Create(AccountType accountType, int customerId, ulong balance)
        {
            //no business rules required, thus we could have use the private constructor directly instead of the factory method

            return new Account (accountType, customerId, balance);
        }

        public void AddTransaction (Transaction transaction)
        {
            if (Transactions == null) Transactions = new List<Transaction>();
            Transactions.Add(transaction);
        }




        
    }
}
