import { Component } from '@angular/core';
import { GroceryInventoryComponent } from './grocery-inventory/grocery-inventory.component';
import { GroceryListComponent } from './grocery-list/grocery-list.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'grocery-app';
}
