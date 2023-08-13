import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup,Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  usersform!:FormGroup
  
  constructor(private fb:FormBuilder){
    
    this.usersform = this.fb.group({
      Name:['',[Validators.required]],
      phonenumber:['',[Validators.required]],
      password:['',[Validators.required,Validators.minLength(8)]],
      confirmPassword:['',[Validators.required]],
      email:['',[Validators.required,Validators.email]],
      address:['',[Validators.required]]
    }
      
    )
  }
  register(data: any) {
console.log(data)
  }
  
}
