import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;
  passwordVisible: boolean = false;

  isLoginWithFb : boolean = false;
  isLoginWithEmail : boolean = false;
  isLogin : boolean = false;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.fb.group({
      formLayout: ["horizontal"],
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });
  }

  signUp() {
    console.log("logined");
  }

  loginWithFb(){

  }

  loginWithEmail(){

  }

}
