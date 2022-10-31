using Bsynchro.Customers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Bsynchro.Controllers.Customers
{
    [RemoteService]
    [Route("api/app/Customers")]
    public class CustomersController : AbpController, ICustomerAppService
    {
        private ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [Route("get-customer")]
        [HttpGet]
        public async Task<CustomerDto> GetCustomer(int id)
        {
            return await _customerAppService.GetCustomer(id);
        }


        [Route("get-all-customers")]
        [HttpGet]
        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            return await _customerAppService.GetAllCustomers();
        }


    }
}
