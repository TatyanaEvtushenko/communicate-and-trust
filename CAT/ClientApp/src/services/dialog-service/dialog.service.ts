import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { Observable } from 'rxjs';
import { Dialog } from "../../models/dialog/dialog";
import { DialogPreview } from "../../models/dialog/dialogPreview";
import { Message } from "../../models/dialog/message";

@Injectable()
export class DialogService {

  constructor(private http: HttpService) {
  }

  getDialogWithUser(userName: string, currentUserName: string): Observable<Dialog> {
    this.http.controllerName = 'dialog';
    return this.http.get(`getDialogWithUser?userName=${userName}&currentUserName=${currentUserName}`);
  }

  getCurrentUserDialogs(currentUserName: string): Observable<DialogPreview[]> {
    this.http.controllerName = 'dialog';
    return this.http.get(`getCurrentUserDialogs?currentUserName=${currentUserName}`);
  }

  postMessage(message: Message): Observable<boolean> {
    this.http.controllerName = 'dialog';
    return this.http.post("postMessage", message);
  }

  readAllMessages(currentUserName: string, userName: string): Observable<boolean> {
    this.http.controllerName = 'dialog';
    return this.http.get(`readAllMessages?userName=${userName}&currentUserName=${currentUserName}`);
  }

}
