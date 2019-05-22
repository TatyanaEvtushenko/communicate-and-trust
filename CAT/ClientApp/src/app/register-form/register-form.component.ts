import { Component, OnInit } from "@angular/core";
import { RegisterAccount } from "../../models/account/register-account";
import { AccountService } from "../../services/account-service/account.service";
import { ActionResult } from "../../models/action-results/base/action-result";

@Component({
  selector: "app-register-form",
  templateUrl: "./register-form.component.html",
  styleUrls: ["./register-form.component.css"]
})
export class RegisterFormComponent implements OnInit {

  public account: RegisterAccount = new RegisterAccount("", "", "", "", "", "", null);
  public result: ActionResult;

  constructor(private accountService: AccountService) {
  }

  ngOnInit() {
  }

  onSubmit() {
    this.accountService.registerUser(this.createFormDataObject()).subscribe(
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

  getFiles(event) {
    this.account.file = event.target.files[0];
  }

  createFormDataObject() : FormData {
    const result = new FormData();
    result.append("file", this.account.file);
    result.append("email", this.account.email);
    result.append("firstName", this.account.firstName);
    result.append("secondName", this.account.secondName);
    result.append("userName", this.account.userName);
    result.append("confirmedPassword", this.account.confirmedPassword);
    result.append("password", this.account.password);
    return result;
  }
}
