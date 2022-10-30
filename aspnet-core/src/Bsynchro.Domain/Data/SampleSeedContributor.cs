using Bsynchro.Accounts;
using Bsynchro.Customers;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Bsynchro.Data
{
    public class SampleSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly ICustomersRepository _customerRepository;

        public SampleSeedContributor(IAccountsRepository accountsRepository, ICustomersRepository customerRepository)
        {
            _accountsRepository = accountsRepository;
            _customerRepository = customerRepository;
        }


        
        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _customerRepository.GetCountAsync() == 0 && await _accountsRepository.GetCountAsync() == 0)
            {
                List<Customer> sampleCustomers = new List<Customer>
                {
                    Customer.Create("Customer1", "sample1"),
                    Customer.Create("Customer2", "sample2")
                };

                await _customerRepository.InsertManyAsync(sampleCustomers, autoSave: true);

                var customers = await _customerRepository.GetQueryableAsync();

                foreach(var customer in customers)
                {
                    var account = Account.Create(AccountType.Current, customer.Id, 0);
                    customer.AddAccount(account);
                }

                await _customerRepository.UpdateManyAsync(customers, autoSave: true);
            }
        }
    }    
}
