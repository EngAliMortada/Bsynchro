import { AuthService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { AccountDto, AccountsService } from '@proxy/accounts';
import { CustomerDto, CustomersService } from '@proxy/customers';
import { TransactionDto, TransactionsService } from '@proxy/transactions';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  get hasLoggedIn(): boolean {
    return this.oAuthService.hasValidAccessToken();
  }
  

  selectedAccount;
  isSaving = false;
  transactions: TransactionDto [] = [];
  accounts: AccountDto [] = [];
  selectedCustomer;
  initialCredit = 0;
  customers?: CustomerDto[] = [];
  constructor(
    private oAuthService: OAuthService,
    private authService: AuthService,
    private customerService: CustomersService,
    private accountservice: AccountsService,
    private transactionService: TransactionsService
    ) {}


  ngOnInit(): void {
      this.customerService.getAllCustomers()
      .subscribe(customers => {
      this.customers = customers
      })       
  }

  addCurrentAccount() {
    if(this.selectedCustomer == undefined) return
    this.isSaving = true
    this.accountservice
    .createCurrentAccountByDto({customerId: this.selectedCustomer, initialCredit:this.initialCredit})
    .subscribe(() => {
      alert('New Account was created')
      this.isSaving = false
      this.initialCredit = 0
    })      
  }

  login() {
    this.authService.navigateToLogin();
  }

  handleCustomerChange() {
    this.accountservice.getCustomerAccountsById(this.selectedCustomer)
    .subscribe (accounts => this.accounts = accounts)
  }

  showTransactions(account) {
    this.selectedAccount = account
    this.transactionService.getAccountTransactionsById(account.id)
    .subscribe(transactions => {
      this.transactions = transactions
    })
  }

  refresh() {
    if(this.accounts.length>0) 
      this.handleCustomerChange();
  }
}
