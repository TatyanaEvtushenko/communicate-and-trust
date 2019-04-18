import { Injectable } from '@angular/core';
import { RegisterAccount } from '../../models/account/register-account';
import { HttpService } from '../http-service/http.service';
import { Observable } from 'rxjs';
import { ActionResult } from '../../models/action-results/action-result';

@Injectable()
export class AccountService {

  constructor(private http: HttpService) {
    http.controllerName = 'account';
  }

  registerUser(user: RegisterAccount): Observable<ActionResult> {
    return this.http.post('register', user);
  }

}
