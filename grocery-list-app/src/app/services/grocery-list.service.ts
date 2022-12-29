import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Grocery } from '../grocery';
import { GroceryList } from '../grocery-list';

@Injectable({
  providedIn: 'root'
})
export class GroceryListService {

  readonly API = "/api/GroceryLists";

  constructor(private http: HttpClient) { }


 /*
 //  This service is not currently in use.  I would like to pull list-related functionality out of grocery.service in the near future.
 */


  getAllLists(): Observable<GroceryList> {
    console.log("getting all grocery lists...");
    return this.http.get<GroceryList>(this.API);
  }

  getList(id: string) : Observable<GroceryList> {
    console.log("getting grocery list...");
    return this.http.get<GroceryList>(
      `${this.API}/Get/${id}`);
  }
  
  createList(list: GroceryList) {
    console.log("creating grocery list...");
    return this.http.post(
      `${this.API}/Create`, list);
  }

  updateList(list: GroceryList) {
    console.log("updating grocery list...");
    return this.http.put(
      `${this.API}/Update`, list);
  }

  deleteList(id: string) {
    console.log("deleting grocery list...");
    return this.http.delete(
      `${this.API}/Delete/${id}`);
  }

}
