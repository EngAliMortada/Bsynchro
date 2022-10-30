using Bsynchro.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bsynchro.Customers
{
    public class Customer : FullAuditedAggregateRoot<int>
    {
        [Required]
        public string Name { get; private set; }
        [Required]
        public string SurName { get; private set; }

        public ulong Balance { get; private set; }

        public virtual ICollection<Account> Accounts { get; private set; }

        protected Customer()
        {

        }

        private Customer(string name, string surName, ulong balance)
        {
            Name = name;
            SurName = surName;
            Balance = balance;
        }

        public static Customer Create (string name, string surName, ulong balance)
        {
            Check.NotNull(name, nameof(name));
            Check.NotNull(surName, nameof(surName));

            return new Customer (name, surName, balance);
        }

        public void SetName (string name)
        {
            Check.NotNull(name, nameof(name));
            Name = name;
        }

        public void SetSurName (string surName)
        {
            Check.NotNull(surName, nameof(surName));
            SurName = surName;
        }

        public void AddAccount (Account account)
        {
            Accounts.Add(account);
        }
    }
}
