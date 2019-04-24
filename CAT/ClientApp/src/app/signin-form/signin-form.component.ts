import { Component, OnInit } from '@angular/core';
import { SignInAccount } from '../../models/account/signin-account';
import { ActionResult } from '../../models/action-results/base/action-result';
import { AccountService } from '../../services/account-service/account.service';
import { AuthorizedUserService } from '../../services/authorized-user-service/authorized-user.service';

@Component({
  selector: 'app-signin-form',
  templateUrl: './signin-form.component.html',
  styleUrls: ['./signin-form.component.css']
})
export class SigninFormComponent implements OnInit {

  public account: SignInAccount = new SignInAccount();
  public result: ActionResult;

  constructor(private accountService: AccountService, private userService: AuthorizedUserService) {
  }

  ngOnInit() {
  }

  public signIn() {
    this.accountService.signIn(this.account).subscribe(
      data => {
        if (data.succeeded) {
          this.userService.saveUserData(data);
        }
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
