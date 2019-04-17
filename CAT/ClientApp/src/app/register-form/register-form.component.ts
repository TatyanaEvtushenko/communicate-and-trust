import { Component, OnInit } from '@angular/core';
import { RegisterAccount } from '../../models/account/register-account';
import { AccountService } from '../../services/account-service/account.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  public account: RegisterAccount = new RegisterAccount();

  constructor(private accountService: AccountService) {
  }

  ngOnInit() {
  }

  public register() {
    this.accountService.registerUser(this.account).subscribe(
      data => {

      }, error => {
        
      });
  }

}
