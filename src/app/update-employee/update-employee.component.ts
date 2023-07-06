import { Component } from '@angular/core';
import { ServicesService } from '../services.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent 

{
  UpdateEmployeeForm!:FormGroup

  constructor(private _Dialog:MatDialog,private ServiceCall: ServicesService, private formbuilder:FormBuilder, private router:ActivatedRoute) { }
  
  ngOnInit(): void {
    this.UpdateEmployeeForm=new FormGroup({
      empName: new FormControl('',[Validators.required]),
      empEmail: new FormControl('',[Validators.required]),
      dob: new FormControl('',[Validators.required]),
      city: new FormControl('',[Validators.required]),
      empPhone: new FormControl(0,[Validators.required])
     
    
      });

      this.router.queryParams.subscribe((param:any)=>
        {
          this.userID = param['id']
          console.warn("check", this.userID);
          
        })
        console.warn(this.userID);
        
      this.getDataById(this.userID);
  }
  userID!: number;
  UpdateEmployee(data:any){
    data.empId=this.userID;
    console.log(this.UpdateEmployeeForm.value);
    this.ServiceCall.UpdateEmployee(data).subscribe((res:any) => {
      alert("Update Successful");
      this._Dialog.closeAll();
      window.location.reload();
      console.warn(res);
      });
  }

  getDataById(id:any)
  {
    this.userID = id;
    this.ServiceCall.GetEmpByEmpId(this.userID).subscribe((res:any)=>{
      this.UpdateEmployeeForm.patchValue(res.data)
      
   })

    
  }
  exit()
  {
    this._Dialog.closeAll();
    alert("Updation Discarded");
  }

 



}

