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
        #region properties
        [Required]
        public string Name { get; private set; }
        [Required]
        public string SurName { get; private set; }

        public virtual ICollection<Account> Accounts { get; private set; }
        #endregion


        protected Customer()
        {

        }

        private Customer(string name, string surName)
        {
            Name = name;
            SurName = surName;
        }

        public static Customer Create (string name, string surName)
        {
            Check.NotNull(name, nameof(name));
            Check.NotNull(surName, nameof(surName));

            return new Customer (name, surName);
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
            if(Accounts == null) Accounts = new List<Account>();
            Accounts.Add(account);
        }




        //this method used only for quick seeding samples
        public static List<Customer> CreateSampleCustomers ()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Customer1", SurName = "One"},
                new Customer {Id = 2, Name = "Customer2", SurName = "Two"}
            };
        }

        public ulong GetTotalBalance ()
        {
            ulong total = 0;
            foreach (var account in Accounts)
            {
                total += account.Balance;
            }

            return total;
        }
    }
}
