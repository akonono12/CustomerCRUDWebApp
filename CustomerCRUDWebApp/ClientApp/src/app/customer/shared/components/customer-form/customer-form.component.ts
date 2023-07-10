import { Customer } from './../../models/customer';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  public GUIDEMPTY:string = '00000000-0000-0000-0000-000000000000';
  @Input() public customer:Customer = new Customer();
  constructor() { }

  ngOnInit() {
  }


  keyPress(event: any) {
    const pattern = /[0-9\+\-\ ]/;

    let inputChar = String.fromCharCode(event.charCode);
    if (event.keyCode != 8 && !pattern.test(inputChar)) {
      event.preventDefault();
    }
  }



}
