using Bsynchro.EntityFrameworkCore;
using EntityFrameworkCore.Triggered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Bsynchro.Triggers
{   
    public class AddTransactionTrigger : IAfterSaveTrigger<Transaction>
    {
        private readonly BsynchroDbContext _db;

        public AddTransactionTrigger(BsynchroDbContext db)
        {
            _db = db;
        }

        public async Task AfterSave(ITriggerContext<Transaction> context, CancellationToken cancellationToken)
        {
            
        }

    }
}
