using Bsynchro.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.ObjectMapping;

namespace Bsynchro.Accounts
{
    [RemoteService(IsEnabled = false)]
    public class AccountsAppService : IAccountsAppService
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IObjectMapper<BsynchroApplicationModule> _objectMapper;

        public AccountsAppService(IAccountsRepository accountsRepository, IObjectMapper<BsynchroApplicationModule> objectMapper)
        {
            _accountsRepository = accountsRepository;            
            _objectMapper = objectMapper;
        }




        #region Getters
        public async Task<List<AccountDto>> GetCustomerAccounts (int id)
        {
            var accounts = await (await _accountsRepository.GetQueryableAsync()).Where(account => account.CustomerId == id).AsNoTracking().ToListAsync();

            return _objectMapper.Map<List<Account>, List<AccountDto>>(accounts);
        }
        public async Task<List<TransactionDto>> GetAccountTransactions (long id)
        {
            var transactions =  (await (await _accountsRepository.GetQueryableAsync())
                .Where(x => x.Id == id)
                .Include(x => x.Transactions)
                .Select(x=>x.Transactions)
                .FirstOrDefaultAsync()).ToList();
                
                
            return _objectMapper.Map<List<Transaction>, List<TransactionDto>>(transactions);
        }
        #endregion


        public async Task<bool> CreateCurrentAccount(InitializeCurrentAccountDto dto)
        {
            try
            {
                var account = await _accountsRepository.InsertAsync(_objectMapper.Map<InitializeCurrentAccountDto, Account>(dto), true);
                
                if (dto.InitialCredit > 0)
                {
                    account.AddTransaction(Transaction.Create(account.Id, dto.InitialCredit, null));
                    await _accountsRepository.UpdateAsync(account, true);
                }

                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}
