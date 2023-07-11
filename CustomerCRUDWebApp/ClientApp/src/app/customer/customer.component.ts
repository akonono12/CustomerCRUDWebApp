import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Customer } from './shared/models/customer';
import { CustomerService } from './shared/customer.service';
import { CustomerTableComponent } from './shared/components/customer-table/customer-table.component';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit,AfterViewInit {
  public customer:Customer = new Customer();
  public GUIDEMPTY:string = '00000000-0000-0000-0000-000000000000';
  @ViewChild("table",{static:false}) customerTable!:CustomerTableComponent;
  constructor(private customerService:CustomerService) { }
  ngAfterViewInit(): void {
    this.customerTable.loadTable();
  }

  ngOnInit() {

  }

  public mappedModel(model:Customer){
    this.customer = model;
  }

  private addCustomer(){
    this.customerService.addCustomer(this.customer).subscribe(data => {
      if(data != this.GUIDEMPTY ){
        alert("Successfully added");
        this.customerTable.loadTable();
      }else{
        alert("Something wrong while adding.Please contact the administrator.")
      }
    })
  }

  private updateCustomer(){
    this.customerService.updateCustomer(this.customer).subscribe(data =>{
      if(data){
        alert("Succesfully updated");
        this.customerTable.loadTable();
      }else{
        alert("Something wrong while updating.Please contact the administrator.")
      }
    })
  }

  public save(){
    if(this.customer.customerID != this.GUIDEMPTY){
      this.updateCustomer();
    }else{
      if(!this.customer.firstName || !this.customer.lastName){
        alert("empty field either first name or last name.Please enter a value.")
        return;
      }
      this.addCustomer();
    }
    this.customer = new Customer();
  }



}
