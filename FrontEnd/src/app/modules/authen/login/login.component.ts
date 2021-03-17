import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  passwordVisible: boolean = false;

  isLoginWithFb : boolean = false;
  isLoginWithEmail : boolean = false;
  isLogin : boolean = false;

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.loginForm = this.fb.group({
      formLayout: ["horizontal"],
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });
  }

  login() {
    console.log("logined");
  }

  loginWithFb(){

  }

  loginWithEmail(){

  }
}
