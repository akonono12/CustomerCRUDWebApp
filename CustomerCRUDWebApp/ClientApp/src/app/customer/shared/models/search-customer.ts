import { Customer } from "./customer";

export class SearchCustomer {
  public totalCount:number = 0;
  public pageIndex:number = 0;
  public pageSize:number = 0;
  public results:Customer[] = [];
}
