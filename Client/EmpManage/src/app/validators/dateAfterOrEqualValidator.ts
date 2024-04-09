import { AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';

export function dateAfterOrEqualValidator(dataEntrance: Date | null): AsyncValidatorFn {
    return (control: AbstractControl): Promise<ValidationErrors | null> => {
        console.log(dataEntrance)
        return new Promise((resolve) => {
            const selectedDate = (control.value);
            if (!selectedDate || !dataEntrance) {
                resolve(null);
                return;
            }

            if (selectedDate >= dataEntrance) {
                resolve(null);
            } else {
                resolve({ dateAfterOrEqual: true });
            }
        });
    };
}