import { Routes } from '@angular/router';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EditEmployeeComponent } from './components/edit-employee/edit-employee.component';
import { EditPositionComponent } from './components/edit-position/edit-position.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PositionDetailsComponent } from './components/position-details/position-details.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { AllEmployeesComponent } from './components/all-employees/all-employees.component';



export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'allEmployee', component: AllEmployeesComponent },
  { path: 'addEmployee', component: AddEmployeeComponent },
  { path: 'editEmployee/:id', component: EditEmployeeComponent },
  { path: 'position', component: PositionDetailsComponent },
  { path: 'editPosition', component: EditPositionComponent },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  { path: '**', component: NotFoundComponent },


];
