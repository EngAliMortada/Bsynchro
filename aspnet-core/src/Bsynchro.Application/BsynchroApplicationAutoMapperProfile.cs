using AutoMapper;
using Bsynchro.Accounts;
using Bsynchro.Customers;
using Bsynchro.Transactions;

namespace Bsynchro;

public class BsynchroApplicationAutoMapperProfile : Profile
{
    public BsynchroApplicationAutoMapperProfile()
    {
        CreateMap<Account, AccountDto>();

        CreateMap<InitializeCurrentAccountDto, Account>()
            .ForMember(destination => destination.AccountType, options => options.MapFrom(src => 0))
            .ForMember(destination => destination.Balance, options => options.MapFrom(src => 0));

        CreateMap<Customer, CustomerDto>()
            .ForMember(destination => destination.Balance, options => options.MapFrom(src => src.GetTotalBalance()));

        CreateMap<Transaction, TransactionDto>();

        CreateMap<TransactionDto, Transaction>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
