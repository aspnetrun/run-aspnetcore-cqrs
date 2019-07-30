import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ProductDataService } from 'src/app/core/services/product-data.service';

@Component({
  selector: 'product-delete-modal',
  templateUrl: './product-delete-modal.component.html',
  styleUrls: ['./product-delete-modal.component.scss']
})
export class ProductDeleteModalComponent implements OnInit {
  @ViewChild('deleteModal', { static: true }) public deleteModal: ModalDirective;
  @Input() productId?: number;
  @Output() productDeleted: EventEmitter<Date> = new EventEmitter<Date>();

  constructor(private dataService: ProductDataService) {
  }

  ngOnInit() {
  }

  show() {
    this.deleteModal.show();
  }

  hide() {
    this.deleteModal.hide();
  }

  delete() {
    this.dataService.deleteProductById(this.productId).subscribe(() => {
      this.productDeleted.emit();
      this.hide();
    });
  }
}
