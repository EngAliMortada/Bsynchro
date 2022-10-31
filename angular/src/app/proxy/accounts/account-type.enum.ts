import { mapEnumToOptions } from '@abp/ng.core';

export enum AccountType {
  Current = 0,
  Saving = 1,
}

export const accountTypeOptions = mapEnumToOptions(AccountType);
