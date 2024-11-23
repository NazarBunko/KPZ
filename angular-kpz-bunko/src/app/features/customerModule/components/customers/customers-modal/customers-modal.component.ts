import { Component, EventEmitter, Output } from '@angular/core';
import { Customer } from '../../../interfaces/Customer';

@Component({
  selector: 'app-customers-modal',
  templateUrl: './customers-modal.component.html',
  styleUrls: ['./customers-modal.component.scss'],
})
export class CustomersModalComponent {
  @Output() closeModal = new EventEmitter<void>();
  @Output() saveCustomer = new EventEmitter<Customer>();

  customer: Customer = {id:0, name: '', type: '', counter: 0,};

  onSave() {
    this.saveCustomer.emit(this.customer);
    this.closeModal.emit();
  }
}
