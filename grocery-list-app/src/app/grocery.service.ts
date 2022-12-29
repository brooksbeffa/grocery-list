import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Grocery } from './grocery';
import {GroceryList } from './grocery-list';

@Injectable({
  providedIn: 'root'
})
export class GroceryService implements OnInit {

  readonly API = "/api/Groceries";

  constructor(private http: HttpClient) { }

  ngOnInit() { }

  getAllGroceries(): Observable<Grocery[]> {
    console.log("getting all groceries...");
    return this.http.get<Grocery[]>(this.API);
  }

  getGrocery(id: string): Observable<Grocery> {
    console.log("getting grocery...");
    return this.http.get<Grocery>(
      `${this.API}/Get/${id}`);
  }

  createGrocery(grocery: Grocery) {
    console.log("creating grocery...");
    return this.http.post(
      `${this.API}/Create`, grocery);
  }

  updateGrocery(grocery: Grocery) {
    console.log("updating grocery...");
    return this.http.put(
      `${this.API}/Update`, grocery);
  } 

  deleteGrocery(id: string) {
    console.log("deleting grocery...");
    return this.http.delete(
      `${this.API}/Delete/${id}`);
  }




  // grocery-list methods

  getAllLists(): Observable<GroceryList> {
    console.log("getting all grocery lists...");
    return this.http.get<GroceryList>(`${this.API}/GetAllLists`);
  }

  getList(id: string) : Observable<GroceryList> {
    console.log("getting grocery list...");
    return this.http.get<GroceryList>(
      `${this.API}/GetList/${id}`);
  }
  

  createList(list: GroceryList) {
    console.log("creating grocery list...");
    return this.http.post(
      `${this.API}/CreateList`, list);
  }

  updateList(list: GroceryList) {
    console.log("updating grocery list...");
    return this.http.put(
      `${this.API}/UpdateList`, list);
  }

  deleteList(id: string) {
    console.log("deleting grocery list...");
    return this.http.delete(
      `${this.API}/DeleteList/${id}`);
  }


  // methods for adding and removing items from a list
  addGroceryToList(groceryID: string, listID: string) : Observable<any> {
    console.log("adding grocery to list...");
    return this.http.post(
      `${this.API}/AddGrocery/${groceryID}/${listID}`, null);
  }


  removeGroceryFromList(groceryID: string, listID: string) : Observable<any> {
    console.log("removing grocery from list...");
    return this.http.delete(
      `${this.API}/RemoveGrocery/${groceryID}/${listID}`);
  }
}
