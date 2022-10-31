using Bsynchro.Accounts;
using Bsynchro.EntityFrameworkCore;
using Bsynchro.Transactions;
using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Bsynchro.Triggers
{   
    //this trigger update the Account balance each time a transaction is inserted
    public class AddTransactionTrigger : IAfterSaveTrigger<Transaction>
    {
        private readonly IAccountsRepository _accountsRepository;


        public AddTransactionTrigger(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task AfterSave(ITriggerContext<Transaction> context, CancellationToken cancellationToken)
        {
            Transaction newTransaction = context.Entity;
            var account = await (await _accountsRepository.GetQueryableAsync())
                .Where(account => account.Id == newTransaction.AccountId)
                .FirstOrDefaultAsync();

            if(account != null)
            {
                account.UpdateBalance(newTransaction);
                await _accountsRepository.UpdateAsync(account, true);
            }
        }
    }
}
