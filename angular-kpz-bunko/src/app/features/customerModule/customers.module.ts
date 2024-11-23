import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HospitalRoutingModule } from './customers-routing.module';
import { HighlightDirective } from 'src/app/shared/directives/highlight.directive';
import { CustomersComponent } from './components/customers/customers.component';
import { CustomersModalComponent } from './components/customers/customers-modal/customers-modal.component';
import { CounterComponent } from './components/counter/counter.component';
import { AppRoutingModule } from 'src/app/app-routing.module';

@NgModule({
  declarations: [
    CustomersComponent,
    CustomersModalComponent,
    CounterComponent,
    HighlightDirective,
  ],
  imports: [CommonModule, FormsModule, HospitalRoutingModule],
})
export class CustomersModule {}
