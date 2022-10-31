using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.ObjectMapping;

namespace Bsynchro.Transactions
{
    [RemoteService(IsEnabled = false)]
    public class TransactionsAppService : ITransactionsAppService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IObjectMapper<BsynchroApplicationModule> _objectMapper;

        public TransactionsAppService(ITransactionsRepository transactionsRepository, IObjectMapper<BsynchroApplicationModule> objectMapper)
        {
            _transactionsRepository = transactionsRepository;
            _objectMapper = objectMapper;
        }

        public async Task<List<TransactionDto>> GetAccountTransactions(long id)
        {
            var transactions = await (await _transactionsRepository.GetQueryableAsync())
                .Where(x => x.AccountId == id)
                .AsNoTracking()
                .ToListAsync();


            return _objectMapper.Map<List<Transaction>, List<TransactionDto>>(transactions);
        }
    }


}
