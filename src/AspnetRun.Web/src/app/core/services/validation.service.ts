import { AbstractControl } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable()
export class ValidationService {

    getValidatorErrorMessage(name: string, value?: any) {
        const config = {
            'required': 'Required',
            'invalidEmailAddress': 'Invalid email address',
            'invalidPassword': 'This regex can be used to restrict passwords to a length of 8 to 20 aplhanumeric characters and select special characters. The password also can not start with a digit, underscore or special character and must contain at least one digit.',
            'minlength': `Minimum length ${value.requiredLength}`,
            'maxlength': `Maximum length ${value.requiredLength}`
        };
        return config[name];
    }

    email(control: AbstractControl) {
        if (control.value.match(/[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/)) {
            return null;
        } else {
            return { 'invalidEmailAddress': true };
        }
    }

    password(control: AbstractControl) {
        if (control.value.match(/^(?=[^\d_].*?\d)\w(\w|[!@#$%]){7,20}/)) {
            return null;
        } else {
            return { 'invalidPassword': true };
        }
    }
}
