using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bsynchro.Accounts
{
    public class Transaction : FullAuditedEntity<Guid>
    {
        public long AccountId { get; private set; }
        public virtual Account Account { get; private set; }
        public ulong? Deposit { get; private set; }
        public ulong? Withdraw { get; private set; }

        protected Transaction()
        {

        }

        private Transaction(long accountId, ulong? deposit, ulong? withdraw)
        {
            AccountId = accountId;
            Deposit = deposit;
            Withdraw = withdraw;
        }

        public static Transaction Create(long accountId, ulong? deposit, ulong? withdraw)
        {
            if (!deposit.HasValue && !withdraw.HasValue)
            {
                throw new Exception(BsynchroDomainErrorCodes.TransactionHasNoValueError);
            }

            if (deposit.HasValue && withdraw.HasValue)
            {
                throw new Exception(BsynchroDomainErrorCodes.TransactionHasWithdrawAndDepositError);
            }

            return new Transaction(accountId, deposit, withdraw);
        }
    }
}
