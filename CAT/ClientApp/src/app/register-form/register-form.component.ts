import { Component, OnInit } from '@angular/core';
import { RegisterAccount } from '../../models/account/register-account';
import { AccountService } from '../../services/account-service/account.service';
import { ActionResult } from '../../models/action-results/action-result';
import { ActionError } from '../../models/action-results/action-error';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  public account: RegisterAccount = new RegisterAccount();
  public result: ActionResult;

  constructor(private accountService: AccountService) {
  }

  ngOnInit() {
  }

  public register() {
    this.accountService.registerUser(this.account).subscribe(
      data => {
        this.result = data;
      }, error => {
        this.result = {
          succeeded: false,
          errors: [
            {
              code: error.status, 
              description: error.statusText
            }
          ]
        };
      }
    );
  }

}
