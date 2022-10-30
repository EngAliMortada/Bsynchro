using Bsynchro.Accounts;
using Bsynchro.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bsynchro.Customers
{
    public class EfCustomersRepository : EfCoreRepository<BsynchroDbContext, Customer, int>, ICustomersRepository
    {
        private readonly IDbContextProvider<BsynchroDbContext> _dbContextProvider;

        public EfCustomersRepository(IDbContextProvider<BsynchroDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
