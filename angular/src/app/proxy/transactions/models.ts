import type { EntityDto } from '@abp/ng.core';

export interface TransactionDto extends EntityDto<string> {
  accountId: number;
  deposit?: number;
  withdraw?: number;
}
