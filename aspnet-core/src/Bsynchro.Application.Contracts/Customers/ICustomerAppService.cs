using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bsynchro.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<CustomerDto> GetCustomer(int id);

        Task<List<CustomerDto>> GetAllCustomers();
    }
}
