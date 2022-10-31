import type { CustomerDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  apiName = 'Default';
  

  getAllCustomers = () =>
    this.restService.request<any, CustomerDto[]>({
      method: 'GET',
      url: '/api/app/Customers/get-all-customers',
    },
    { apiName: this.apiName });
  

  getCustomerById = (id: number) =>
    this.restService.request<any, CustomerDto>({
      method: 'GET',
      url: '/api/app/Customers/get-customer',
      params: { id },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
