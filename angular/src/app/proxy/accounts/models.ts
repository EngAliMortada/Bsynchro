import type { EntityDto } from '@abp/ng.core';
import type { AccountType } from './account-type.enum';

export interface AccountDto extends EntityDto<number> {
  accountType: AccountType;
  customerId: number;
  balance: number;
}

export interface InitializeCurrentAccountDto {
  customerId: number;
  initialCredit: number;
}
