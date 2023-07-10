import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CustomerService } from '../../customer.service';
import { Customer } from '../../models/customer';
import { SearchCustomer } from '../../models/search-customer';

@Component({
  selector: 'app-customer-table',
  templateUrl: './customer-table.component.html',
  styleUrls: ['./customer-table.component.css']
})
export class CustomerTableComponent implements OnInit {

  public customerFilter: Customer = new Customer();
  public customers:Customer[] = [];
  public pageIndex:number = 1;
  public totalCount:number = 0;
  public searchList:SearchCustomer = new SearchCustomer();
  @Output() edit: EventEmitter<Customer> = new EventEmitter();
  constructor(private customerService:CustomerService) { }

  ngOnInit() {
  }

  public loadTable(){
    this.customerService.searchCustomer(this.pageIndex,this.customerFilter).subscribe(data => {
      this.customers = data.results;
      this.totalCount = data.totalCount;
      this.pageIndex = data.pageIndex;
      this.searchList = data;
    })
  }

  public handlePageChange(event: number): void {
    this.pageIndex = event;
    this.loadTable();
  }

  public deleteCustomer(model:Customer){
    if(confirm(`Are you sure you want to delete: ${model.firstName} ${model.lastName} ?`)){
      this.customerService.deleteCustomer(model.customerID).subscribe(result => {
        if(result){
          alert("Succesfully deleted");
          this.loadTable();
        }else{
          alert("Something wrong while deleting.Please contact the administrator.")
        }
      })
    }
  }

  public onClickEdit(model:Customer){
    this.edit.emit(model);
  }

  keyPress(event: any) {
    const pattern = /[0-9\+\-\ ]/;

    let inputChar = String.fromCharCode(event.charCode);
    if (event.keyCode != 8 && !pattern.test(inputChar)) {
      event.preventDefault();
    }
  }

  public search(){
    this.pageIndex = 1;
    this.loadTable();
  }

}
