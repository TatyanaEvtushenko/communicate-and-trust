import { Injectable } from '@angular/core';
import { TokenActionResult } from '../../models/action-results/token-action-result';
import { SessionStorage } from '../../utils/session-storage';

@Injectable()
export class AuthorizedUserService {

  static isAuthorized: boolean = AuthorizedUserService.getAuthorizedStatus();

  static getAuthorizedStatus() {    
    let token = SessionStorage.getToken();
    return token != undefined && token != null;
  }

  saveUserData(data: TokenActionResult) {
    AuthorizedUserService.isAuthorized = true;
    SessionStorage.saveToken(data.accessToken);
    SessionStorage.saveUserName(data.userName);
    SessionStorage.saveUserAvatar(data.avatarUrl);
    SessionStorage.saveRole(data.role);
  }

  removeUserData() {
    AuthorizedUserService.isAuthorized = false;
    SessionStorage.removeToken();
    SessionStorage.removeUserName();
    SessionStorage.removeUserAvatar();
    SessionStorage.removeRole();
  }

}
