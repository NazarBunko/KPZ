import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CounterComponent } from './features/customerModule/components/counter/counter.component';

const routes: Routes = [
  { path: '', redirectTo: '/customers', pathMatch: 'full' },
  { path: 'counters', pathMatch: 'full', component: CounterComponent  },
  {
    path: 'customers',
    loadChildren: () =>
      import('./features/customerModule/customers.module').then((m) => m.CustomersModule),
  },
  { path: '**', redirectTo: '/customers' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
