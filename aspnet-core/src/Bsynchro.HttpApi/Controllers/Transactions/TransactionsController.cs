using Bsynchro.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Bsynchro.Controllers.Transactions
{
    [RemoteService]
    [Route("api/app/Customers")]
    public class TransactionsController: AbpController, ITransactionsAppService
    {
        private ITransactionsAppService _transactionsAppService;
        public TransactionsController(ITransactionsAppService transactionsAppService)
        {
            _transactionsAppService = transactionsAppService;
        }
    }
}
