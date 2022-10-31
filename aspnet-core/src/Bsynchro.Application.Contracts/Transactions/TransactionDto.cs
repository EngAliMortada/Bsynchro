using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Bsynchro.Transactions
{
    public class TransactionDto : EntityDto<Guid>
    {
        public long AccountId { get; set; }
        public ulong? Deposit { get; set; }
        public ulong? Withdraw { get; set; }
    }
}
