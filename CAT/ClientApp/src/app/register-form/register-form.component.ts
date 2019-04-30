import { Component, OnInit, ViewChild } from '@angular/core';
import { RegisterAccount } from '../../models/account/register-account';
import { AccountService } from '../../services/account-service/account.service';
import { ActionResult } from '../../models/action-results/base/action-result';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  public account: RegisterAccount = new RegisterAccount();
  public result: ActionResult;
  formData:any;
  
  @ViewChild('fileInput') fileInput:any;

  constructor(private accountService: AccountService) {
  }

  ngOnInit() {
  }

  onFileChange(event) {
    // let nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    // let input = new FormData(); 
    // input.append("filesData", nativeElement.files[0]);
    // this.account.avatarImage = input;
    if(event.target.files.length > 0) {      
      this.formData = new FormData();
      this.formData.append("avatarImage", event.target.files[0]);
      // this.account.avatarImage = formData;
    }
  }

  register() {
    this.accountService.registerUser(this.formData).subscribe(
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
