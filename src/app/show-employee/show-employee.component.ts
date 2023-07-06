import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ServicesService } from '../services.service';
import { MatTableDataSource } from '@angular/material/table';
import { UpdateEmployeeComponent } from '../update-employee/update-employee.component';

@Component({
  selector: 'app-show-employee',
  templateUrl: './show-employee.component.html',
  styleUrls: ['./show-employee.component.css']
})
export class ShowEmployeeComponent {
  Users:any=[]
  dataSource:any;
  displayedColumns: string[] = ['Employee Id','Employee Name','Email', 'DOB', 'city','Phone','edit','delete'];	

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private ServiceCall: ServicesService, private route: Router, private _Dialog:MatDialog) { }
  ngOnInit()
  {
    this.ServiceCall.GetAllEmployee().subscribe((res:any)=>{
      console.log(res.dataList)

      if(res != null){
        this.dataSource = new MatTableDataSource<any>(res.dataList);
        console.log(res.dataList)
      }
    })
  }

  
  val:any=[]
  getDataById(id:any){
   
    this.route.navigate([this._Dialog.open(UpdateEmployeeComponent)],{queryParams:{id:id}})
  }


  Delete(id:any)
  {
    debugger
    alert('Click Ok for Conformation');
    this.ServiceCall.DeleteEmployee(id).subscribe(res=>{
      alert("Employee Deleted Successfully");
      window.location.reload();

    })
  }


}