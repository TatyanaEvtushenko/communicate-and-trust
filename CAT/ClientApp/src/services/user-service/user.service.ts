import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { Observable } from 'rxjs';
import { User } from '../../models/user/User';

@Injectable()
export class UserService {

  constructor(private http: HttpService) {
    http.controllerName = 'user';
  }

  getTopTenUsers(): Observable<User[]> {
    this.http.controllerName = 'user';
    return this.http.get('top10');
  }

  getUsersByString(searchString: string): Observable<User[]> {
    return this.http.get(`usersSearch?searchString=${searchString}`);
  }

}
