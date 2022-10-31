using Bsynchro.Accounts;
using Bsynchro.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc;

namespace Bsynchro.Controllers.Accounts
{
    [RemoteService]
    [Route("api/app/Accounts")]
    public class AccountsController: AbpController, IAccountsAppService
    {
        private IAccountsAppService _accountsAppService;

        public AccountsController(IAccountsAppService accountAppService)
        {
            _accountsAppService = accountAppService;
        }

        [Route("get-customer-accounts")]
        [HttpGet]
        public async Task<List<AccountDto>> GetCustomerAccounts(int id)
        {
            return await _accountsAppService.GetCustomerAccounts(id);
        }

        [Route("get-account-transactions")]
        [HttpGet]
        public async Task<List<TransactionDto>> GetAccountTransactions(long id)
        {
            return await _accountsAppService.GetAccountTransactions(id);
        }

        [Route("create-current-account")]
        [HttpPost]
        public async Task<bool> CreateCurrentAccount(InitializeCurrentAccountDto dto)
        {
            return await _accountsAppService.CreateCurrentAccount(dto);
        }
    }
}
