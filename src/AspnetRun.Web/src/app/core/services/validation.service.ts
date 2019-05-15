import { AbstractControl } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable()
export class ValidationService {

    getValidatorErrorMessage(name: string, value?: any) {
        const config = {
            'required': 'Required',
            'invalidEmailAddress': 'Invalid email address',
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
}
