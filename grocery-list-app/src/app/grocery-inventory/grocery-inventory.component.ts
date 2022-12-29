import { Component, OnInit } from '@angular/core';

import { Grocery } from '../grocery';
import { GroceryService } from '../grocery.service';


@Component({
  selector: 'grocery-inventory',
  templateUrl: './grocery-inventory.component.html',
  styleUrls: ['./grocery-inventory.component.css']
})
export class GroceryInventoryComponent implements OnInit {

  groceries: Grocery[] = [];
  newGrocery: Grocery = { groceryID: '', price: 0 };
  selectedList = "my list";

  constructor(private groceryService: GroceryService) {}

  ngOnInit() {
    this.refreshInventory();
  }

  refreshInventory() {
    console.log('Refreshing inventory...');
    this.groceryService.getAllGroceries().subscribe(groceries => this.groceries = groceries);

    // reset the newGrocery variable. This won't be necessery with proper data binding
    this.newGrocery = { groceryID: '', price: 0 };
  }

  createGrocery(id: string) {
    this.newGrocery.groceryID = id;
    this.groceryService.createGrocery(this.newGrocery).subscribe(grocery => {  
      this.refreshInventory() ,
      console.log("created grocery: " + JSON.stringify(grocery)); 
    });
  }

  getGrocery(id: string) {
    this.groceryService.getGrocery(id).subscribe(grocery => {
      console.log("got grocery: " + JSON.stringify(grocery));
    });
  }

  addToList(groceryID: string){
    console.log("adding to list...");
    this.groceryService.addGroceryToList(groceryID, this.selectedList).subscribe();
  }

}
