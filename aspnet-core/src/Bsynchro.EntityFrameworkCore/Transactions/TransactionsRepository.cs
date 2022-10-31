using Bsynchro.Accounts;
using Bsynchro.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bsynchro.Transactions
{
    public class EfTransactionsRepository : EfCoreRepository<BsynchroDbContext, Transaction, Guid>, ITransactionsRepository
    {
        private readonly IDbContextProvider<BsynchroDbContext> _dbContextProvider;

        public EfTransactionsRepository(IDbContextProvider<BsynchroDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
