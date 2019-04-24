import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-auth-form',
  templateUrl: './auth-form.component.html',
  styleUrls: ['./auth-form.component.css']
})
export class AuthFormComponent implements OnInit {

  isSignInForm = true;

  constructor() { }

  ngOnInit() {
  }

  selectSignInForm() {
    this.isSignInForm = true;
  }

  selectRegisterForm() {
    this.isSignInForm = false;
  }

}
