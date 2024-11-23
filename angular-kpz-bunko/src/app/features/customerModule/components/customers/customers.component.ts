import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customerservice';
import { Customer } from '../../interfaces/Customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
})
export class CustomersComponent implements OnInit {
  isModalOpen = false;
  customers: Customer[] = [];

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.fetchCustomers();
  }

  fetchCustomers(): void {
    this.customerService.getCustomers().subscribe((data) => {
      this.customers = data;
    });
  }

  openModal() {
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
  }

  onSaveCustomer(newCustomer: Customer) {
    this.customers.push(newCustomer);
    this.closeModal();
  }
}
