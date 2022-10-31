using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bsynchro.Transactions;
using Volo.Abp.Application.Services;

namespace Bsynchro.Accounts
{
    public interface IAccountsAppService: IApplicationService
    {
        Task<List<AccountDto>> GetCustomerAccounts(int id);
        Task<List<TransactionDto>> GetAccountTransactions(long id);
        Task<bool> CreateCurrentAccount(InitializeCurrentAccountDto dto);
    }
}
