import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from './models/customer';
import { SearchCustomer } from './models/search-customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customerUrl:string = environment.baseUrl;
  constructor(private httpClient: HttpClient) { }

  public addCustomer(customer:Customer){
    return this.httpClient.post<string>(`${this.customerUrl}/`,{...customer})
  }

  public updateCustomer(customer:Customer){
    return this.httpClient.put<boolean>(`${this.customerUrl}/`,{...customer})
  }

  public deleteCustomer(id:string){
    return this.httpClient.delete<boolean>(`${this.customerUrl}/`,{body:{id}})
  }

  public searchCustomer(pageIndex:number,filter:Customer){
    return this.httpClient.get<SearchCustomer>(`${this.customerUrl}/search?pageIndex=${pageIndex}&filter.lastName=${filter.lastName}
    &filter.firstName=${filter.firstName}&filter.address=${filter.address}&filter.contactNumber=${filter.contactNumber}`)
  }

  public getCustomer(id:string){
    return this.httpClient.get<Customer>(`${this.customerUrl}/${id}`)
  }
}
