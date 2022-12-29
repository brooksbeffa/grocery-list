import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Grocery } from '../grocery';
import {GroceryList } from '../grocery-list';

@Injectable({
  providedIn: 'root'
})
export class GroceryService {

  readonly groceryController = "/api/Groceries";
  readonly groceryListController = "/api/GroceryLists";
  readonly groceryListGroceryController = "/api/GroceryListGroceries";

  constructor(private http: HttpClient) { }


  getAllGroceries(): Observable<Grocery[]> {
    console.log("getting all groceries...");
    return this.http.get<Grocery[]>(this.groceryController);
  }

  getGrocery(id: string): Observable<Grocery> {
    console.log("getting grocery...");
    return this.http.get<Grocery>(
      `${this.groceryController}/Get/${id}`);
  }

  createGrocery(grocery: Grocery) {
    console.log("creating grocery...");
    return this.http.post(
      `${this.groceryController}/Create`, grocery);
  }

  updateGrocery(grocery: Grocery) {
    console.log("updating grocery...");
    return this.http.put(
      `${this.groceryController}/Update`, grocery);
  } 

  deleteGrocery(id: string) {
    console.log("deleting grocery...");
    return this.http.delete(
      `${this.groceryController}/Delete/${id}`);
  }




  // grocery-list methods

  getAllLists(): Observable<GroceryList> {
    console.log("getting all grocery lists...");
    return this.http.get<GroceryList>(this.groceryListController);
  }

  getList(id: string) : Observable<GroceryList> {
    console.log("getting grocery list...");
    return this.http.get<GroceryList>(
      `${this.groceryListController}/Get/${id}`);
  }
  
  createList(list: GroceryList) {
    console.log("creating grocery list...");
    return this.http.post(
      `${this.groceryListController}/Create`, list);
  }

  updateList(list: GroceryList) {
    console.log("updating grocery list...");
    return this.http.put(
      `${this.groceryListController}/Update`, list);
  }

  deleteList(id: string) {
    console.log("deleting grocery list...");
    return this.http.delete(
      `${this.groceryListController}/Delete/${id}`);
  }


  // methods for adding and removing items from a list
  addGroceryToList(groceryID: string, listID: string) : Observable<any> {
    console.log("adding grocery to list...");
    return this.http.post(
      `${this.groceryListGroceryController}/AddGrocery/${groceryID}/${listID}`, null);
  }

  removeGroceryFromList(groceryID: string, listID: string) : Observable<any> {
    console.log("removing grocery from list...");
    return this.http.delete(
      `${this.groceryListGroceryController}/RemoveGrocery/${groceryID}/${listID}`);
  }
}
