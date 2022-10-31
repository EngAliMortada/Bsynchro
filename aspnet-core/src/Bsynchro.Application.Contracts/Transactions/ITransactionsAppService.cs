using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bsynchro.Transactions
{
    public interface ITransactionsAppService : IApplicationService
    {
        Task<List<TransactionDto>> GetAccountTransactions(long id);
    }
}
