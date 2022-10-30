using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Bsynchro.Customers
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}
