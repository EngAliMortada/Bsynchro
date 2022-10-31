import type { TransactionDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TransactionsService {
  apiName = 'Default';
  

  getAccountTransactionsById = (id: number) =>
    this.restService.request<any, TransactionDto[]>({
      method: 'GET',
      url: '/api/app/Customers/get-account-transactions',
      params: { id },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
