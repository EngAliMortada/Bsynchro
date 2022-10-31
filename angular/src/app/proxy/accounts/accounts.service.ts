import type { AccountDto, InitializeCurrentAccountDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { TransactionDto } from '../transactions/models';

@Injectable({
  providedIn: 'root',
})
export class AccountsService {
  apiName = 'Default';
  

  createCurrentAccountByDto = (dto: InitializeCurrentAccountDto) =>
    this.restService.request<any, boolean>({
      method: 'POST',
      url: '/api/app/Accounts/create-current-account',
      body: dto,
    },
    { apiName: this.apiName });
  

  getAccountTransactionsById = (id: number) =>
    this.restService.request<any, TransactionDto[]>({
      method: 'GET',
      url: '/api/app/Accounts/get-account-transactions',
      params: { id },
    },
    { apiName: this.apiName });
  

  getCustomerAccountsById = (id: number) =>
    this.restService.request<any, AccountDto[]>({
      method: 'GET',
      url: '/api/app/Accounts/get-customer-accounts',
      params: { id },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
