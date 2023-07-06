import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  constructor(private http:HttpClient) {

   }
  GetAllEmployee()
  {
    return this.http.get<any>('http://localhost:5068/api/Employee/GetAllEmployeeDetails');
  }

  
  PostEmployee(a:any)
  {
    return this.http.post('http://localhost:5068/api/Employee/SaveEmployeeDetails',a);
  }

  UpdateEmployee(x:any)
  {
    console.log(x);
    
    return this.http.put<any>('http://localhost:5068/api/Employee/UpdateEmployeeDetails',x);
  }

  GetEmpByEmpId(val:any)
  {
    return this.http.get('http://localhost:5068/api/Employee/GetEmployeeDetails/id?id='+ val);
  }
 
  DeleteEmployee(val:any)
  {
    return this.http.delete('http://localhost:5068/api/Employee/DeleteEmplyee/id?id='+val)
  }
}