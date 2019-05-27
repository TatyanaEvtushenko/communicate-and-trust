import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { Observable } from 'rxjs';
import { Session } from "../../models/session/session";

@Injectable()
export class SessionService {

  constructor(private http: HttpService) {
  }

  getSessions(currentUserName: string): Observable<Session[]> {
    this.http.controllerName = 'session';
    return this.http.get(`getSessions?currentUserName=${currentUserName}`);
  }

}
