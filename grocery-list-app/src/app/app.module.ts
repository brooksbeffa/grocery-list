import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { GroceryInventoryComponent } from './grocery-inventory/grocery-inventory.component';
import { GroceryListComponent } from './grocery-list/grocery-list.component';
//import { HttpHeadersInterceptor } from './http-headers.interceptor';


@NgModule({
  imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule ],
  declarations: [AppComponent, GroceryInventoryComponent, GroceryListComponent ],
  bootstrap: [AppComponent],
})
export class AppModule {}
