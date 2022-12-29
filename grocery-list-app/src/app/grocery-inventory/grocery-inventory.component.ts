import { Component, OnInit } from '@angular/core';

import { Grocery } from '../grocery';
import { GroceryService } from '../services/grocery.service';


@Component({
  selector: 'grocery-inventory',
  templateUrl: './grocery-inventory.component.html',
  styleUrls: ['./grocery-inventory.component.css']
})
export class GroceryInventoryComponent implements OnInit {

  groceries: Grocery[] = [];
  newGrocery: Grocery = { groceryID: '', price: 0, description: '' };
  selectedList = "my list";

  constructor(private groceryService: GroceryService) {}

  ngOnInit() {
    this.refreshInventory();
  }

  refreshInventory() {
    this.groceryService.getAllGroceries().subscribe(groceries => this.groceries = groceries);
    this.newGrocery = { groceryID: '', price: 0, description: '' };
  }

  createGrocery(id: string) {
    this.newGrocery.groceryID = id;
    this.groceryService.createGrocery(this.newGrocery).subscribe(grocery => {  
      this.refreshInventory()
    });
  }

  getGrocery(id: string) {
    this.groceryService.getGrocery(id).subscribe(grocery => { });
  }

  addToList(groceryID: string){
    this.groceryService.addGroceryToList(groceryID, this.selectedList).subscribe();
  }

}
