using AutoMapper;
using Bsynchro.Accounts;
using Bsynchro.Customers;

namespace Bsynchro;

public class BsynchroApplicationAutoMapperProfile : Profile
{
    public BsynchroApplicationAutoMapperProfile()
    {
        CreateMap<Account, AccountDto>();

        CreateMap<InitializeCurrentAccountDto, Account>()
            .ForMember(x => x.AccountType, options => options.MapFrom(src => 0))
            .ForMember(x => x.Balance, options => options.MapFrom(src => 0));

        CreateMap<Customer, CustomerDto>();

        CreateMap<Transaction, TransactionDto>();

        CreateMap<TransactionDto, Transaction>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
