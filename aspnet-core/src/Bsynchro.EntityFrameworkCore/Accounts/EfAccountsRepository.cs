using Bsynchro.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bsynchro.Accounts
{
    public class EfAccountsRepository : EfCoreRepository<BsynchroDbContext, Account, long>, IAccountsRepository
    {
        private readonly IDbContextProvider<BsynchroDbContext> _dbContextProvider;

        public EfAccountsRepository(IDbContextProvider<BsynchroDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
