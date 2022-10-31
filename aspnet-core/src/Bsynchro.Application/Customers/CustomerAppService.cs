using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using System.Reflection;

namespace Bsynchro.Customers
{
    [RemoteService(IsEnabled = false)]
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomersRepository _customerRepository;
        private readonly IObjectMapper<BsynchroApplicationModule> _objectMapper;
        public CustomerAppService(ICustomersRepository customerRepository, IObjectMapper<BsynchroApplicationModule> objectMapper)
        {
            _customerRepository = customerRepository;
            _objectMapper = objectMapper;
        }

        public async Task<CustomerDto> GetCustomer(int id)
        {
            var customer = await (await _customerRepository.GetQueryableAsync()).Where(customer => customer.Id == id)
                .Include(customer => customer.Accounts)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return _objectMapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetAllCustomers ()
        {
            var customers = await (await _customerRepository.GetQueryableAsync()).ToListAsync();

            return _objectMapper.Map<List<Customer>, List<CustomerDto>>(customers);
        }
    }
}
