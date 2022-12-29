import { Component, OnInit } from '@angular/core';
import { Grocery } from '../grocery';
import { GroceryList } from '../grocery-list';
import { GroceryService } from '../grocery.service';
import { interval, Subscription, timer } from 'rxjs';

@Component({
  selector: 'grocery-list',
  templateUrl: './grocery-list.component.html',
  styleUrls: ['./grocery-list.component.css']
})


export class GroceryListComponent implements OnInit {

  selectedList = "my list";
  list : GroceryList = { groceryListID: '', groceries: [] };
  subscription !: Subscription;

  constructor(private groceryService: GroceryService) { }

  ngOnInit() {
    this.refreshList();

    this.subscription = timer(0, 5000).subscribe(_ => this.refreshList());
  }

  refreshList(){
    console.log("refreshing list...");
    this.groceryService.getList(this.selectedList).subscribe(list => this.list = list);
  }

  remove(groceryID: string){
    console.log("removing...");
    this.groceryService.removeGroceryFromList(groceryID, this.selectedList).subscribe(_ => this.refreshList());
  }
}


