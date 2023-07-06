import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ServicesService } from '../services.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {

  constructor(private _Dialog:MatDialog, private ServiceCall: ServicesService, private route: Router,private formBuilder:FormBuilder) { }

 ngOnInit()
 {

 }
  AddEmployee=new FormGroup({
    // employeeId: new FormControl(''),
    empName: new FormControl('',[Validators.required]),
    empEmail: new FormControl('',[Validators.required]),
    dob: new FormControl('',[Validators.required]),
    city: new FormControl('',[Validators.required]),
    empPhone: new FormControl(0,[Validators.required])
   
  
    });

    PostEmployee(data:any)
    {
      this.ServiceCall.PostEmployee(data).subscribe(res=>{
        alert("Data Saved Successfully");
          console.log(data);
          
        location.reload();
    });
          
    
    }
    exit()
    {
      this._Dialog.closeAll();
    }
}
