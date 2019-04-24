export class SessionStorage {

  private static tokenKey: string = "accessToken";
  private static userNameKey: string = "userName";
  private static roleKey: string = "role";

  static saveToken(token: string) {
    sessionStorage.setItem(this.tokenKey, token);
  }

  static getToken(): string {
    return sessionStorage.getItem(this.tokenKey);
  }

  static removeToken() {
    sessionStorage.removeItem(this.tokenKey);
  }

  static saveUserName(userName: string) {
    sessionStorage.setItem(this.userNameKey, userName);
  }

  static getUserName(): string {
    return sessionStorage.getItem(this.userNameKey);
  }

  static removeUserName() {
    sessionStorage.removeItem(this.userNameKey);
  }

  static saveRole(role: string) {
    sessionStorage.setItem(this.roleKey, role);
  }

  static getRole(): string {
    return sessionStorage.getItem(this.roleKey);
  }

  static removeRole() {
    sessionStorage.removeItem(this.roleKey);
  }

}