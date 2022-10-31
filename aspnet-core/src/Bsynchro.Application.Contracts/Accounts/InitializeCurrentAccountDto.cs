using System;
using System.Collections.Generic;
using System.Text;

namespace Bsynchro.Accounts
{
    public class InitializeCurrentAccountDto
    {
        public int CustomerId { get; set; }
        public ulong InitialCredit { get; set; }
    }
}
