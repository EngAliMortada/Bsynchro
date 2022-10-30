using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Bsynchro.Accounts
{
    public class AccountDto : EntityDto<long>
    {
        public AccountType AccountType { get; set; }
        public int CustomerId { get; set; }
        public ulong Balance { get; set; }
    }
}


