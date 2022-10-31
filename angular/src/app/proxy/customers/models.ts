import type { EntityDto } from '@abp/ng.core';

export interface CustomerDto extends EntityDto<number> {
  name: string;
  surName: string;
}
