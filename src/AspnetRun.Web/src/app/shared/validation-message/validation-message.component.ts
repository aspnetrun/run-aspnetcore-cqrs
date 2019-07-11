import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ValidationService } from 'src/app/core/services/validation.service';

@Component({
  selector: 'ar-validation-message',
  template: '<div style="width:100%;margin-top:.25rem;font-size:80%;color:#dc3545">{{errorMessage}}</div>'
})
export class ValidationMessageComponent {
  @Input() control: FormControl;

  constructor(private validationService: ValidationService) {
  }

  get errorMessage() {
    if (this.control.errors) {
      for (let propertyName in this.control.errors) {
        if (this.control.errors.hasOwnProperty(propertyName) && this.control.touched) {
          return this.validationService.getValidatorErrorMessage(propertyName, this.control.errors[propertyName]);
        }
      }
    }

    return null;
  }
}
