import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { GroceryInventoryComponent } from './grocery-inventory/grocery-inventory.component';
import { GroceryListComponent } from './grocery-list/grocery-list.component';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientModule,
      ],
      declarations: [
        AppComponent,
        GroceryListComponent,
        GroceryInventoryComponent
      ],
    }).compileComponents();
  });

  it('should create Grocery List', () => {
    const fixture = TestBed.createComponent(GroceryListComponent);
    const list = fixture.componentInstance;
    expect(list).toBeTruthy();
  });
  
  it('should create Grocery Inventory', () => {
    const fixture = TestBed.createComponent(GroceryInventoryComponent);
    const inventory = fixture.componentInstance;
    expect(inventory).toBeTruthy();
  });

  // it(`should have as title 'grocery-app'`, () => {
  //   const fixture = TestBed.createComponent(AppComponent);
  //   const app = fixture.componentInstance;
  //   expect(app.title).toEqual('grocery-app');
  // });

  // it('should render title', () => {
  //   const fixture = TestBed.createComponent(AppComponent);
  //   fixture.detectChanges();
  //   const compiled = fixture.nativeElement as HTMLElement;
  //   expect(compiled.querySelector('.content span')?.textContent).toContain('grocery-app app is running!');
  // });
});
