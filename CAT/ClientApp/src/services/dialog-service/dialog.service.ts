import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { Observable } from 'rxjs';
import { Dialog } from "../../models/dialog/dialog";

@Injectable()
export class DialogService {

  constructor(private http: HttpService) {
    http.controllerName = 'dialog';
  }

  getDialogWithUser(userName: string): Observable<Dialog> {
    return this.http.get(`getDialogWithUser?userName=${userName}`);
  }

  getCurrentUserDialogs(): Observable<Dialog[]> {
    return this.http.get("getCurrentUserDialogs");
  }

}
