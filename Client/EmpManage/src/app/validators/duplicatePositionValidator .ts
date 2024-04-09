import { ValidatorFn, AbstractControl, ValidationErrors } from "@angular/forms";
import { EmployeePosition } from "../models/employeePosition.model";

export function duplicatePositionValidator( id:number, employeePositions: EmployeePosition[]): ValidatorFn {
 
  return (control: AbstractControl): Promise<ValidationErrors | null> => {
    const newPositionId: number = control.value as number;
     
    if (isNaN(newPositionId) || !employeePositions) {
      return Promise.resolve(null);
    }

    return new Promise((resolve) => {
    
        const isDuplicate = employeePositions.some(
          position => position.positionId == newPositionId && position.id!=id
        );
        resolve(isDuplicate ? { duplicatePosition: true } : null);
    
    });
  };
}
