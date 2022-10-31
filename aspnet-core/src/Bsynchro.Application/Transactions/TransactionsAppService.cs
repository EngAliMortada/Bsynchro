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

    }
}
