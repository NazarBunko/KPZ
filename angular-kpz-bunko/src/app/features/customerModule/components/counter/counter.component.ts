import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customerservice';
import { Customer } from '../../interfaces/Customer';

@Component({
  selector: 'app-counters',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.scss'],
})
export class CounterComponent implements OnInit {
  counters: number[] = [];

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.fetchCounters();
  }

  fetchCounters(): void {
    this.customerService.getCustomers().subscribe((customers: Customer[]) => {
      this.counters = [...new Set(customers.map((customer) => customer.counter))];
    });
  }
}
