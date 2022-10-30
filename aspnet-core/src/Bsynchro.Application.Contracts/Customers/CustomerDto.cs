using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bsynchro.Customers
{
    public class CustomerDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }

        public ulong Balance { get; set; }
    }
}
