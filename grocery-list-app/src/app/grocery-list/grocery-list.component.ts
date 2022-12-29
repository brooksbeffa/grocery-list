import { Component, OnInit } from '@angular/core';
import { Grocery } from '../grocery';
import { GroceryList } from '../grocery-list';
import { GroceryService } from '../services/grocery.service';
import { interval, Subscription, timer } from 'rxjs';
import { formatNumber } from '@angular/common';

@Component({
  selector: 'grocery-list',
  templateUrl: './grocery-list.component.html',
  styleUrls: ['./grocery-list.component.css']
})


export class GroceryListComponent implements OnInit {

  selectedList = "my list";
  list : GroceryList = { groceryListID: '', groceries: [] };
  subscription !: Subscription;
  total: number = 0;

  constructor(private groceryService: GroceryService) { }

  ngOnInit() {
    this.refreshList();
    this.subscription = timer(0, 5000).subscribe(_ => this.refreshList());
  }

  refreshList(){
    this.groceryService.getList(this.selectedList).subscribe(list => { 
      this.list = list, 
      this.calculateTotal() 
    });
  }

  remove(groceryID: string){
    this.groceryService.removeGroceryFromList(groceryID, this.selectedList).subscribe(_ => this.refreshList());
  }

  calculateTotal() {
    this.total = 0;
    this.list.groceries.forEach(grocery => this.total += grocery.price)
  }
}
