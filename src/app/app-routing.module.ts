import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShowEmployeeComponent } from './show-employee/show-employee.component';

const routes: Routes = [
  {
    path:'home',
    component: HomeComponent
  },
  {
    path:'show',
    component: ShowEmployeeComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 
 }
