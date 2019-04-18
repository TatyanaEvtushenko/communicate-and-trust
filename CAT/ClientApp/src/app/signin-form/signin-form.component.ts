import { Component, OnInit } from '@angular/core';
import { SignInAccount } from '../../models/account/signin-account';
import { ActionResult } from '../../models/action-results/base/action-result';
import { AccountService } from '../../services/account-service/account.service';
import { SessionStorage } from '../../utils/session-storage';
import { TokenActionResult } from '../../models/action-results/token-action-result';

@Component({
  selector: 'app-signin-form',
  templateUrl: './signin-form.component.html',
  styleUrls: ['./signin-form.component.css']
})
export class SigninFormComponent implements OnInit {

  public account: SignInAccount = new SignInAccount();
  public result: ActionResult;

  constructor(private accountService: AccountService) {
  }

  ngOnInit() {
  }

  public signIn() {
    this.accountService.signIn(this.account).subscribe(
      data => {
        if (data.succeeded) {
          this.saveUserData(data);
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

  private saveUserData(data: TokenActionResult) {
    SessionStorage.saveToken(data.accessToken);
    SessionStorage.saveUserName(data.userName);
    SessionStorage.saveRole(data.role);
  }
}
