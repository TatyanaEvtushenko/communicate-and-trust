"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SessionStorage = /** @class */ (function () {
    function SessionStorage() {
    }
    SessionStorage.saveToken = function (token) {
        sessionStorage.setItem(this.tokenKey, token);
    };
    SessionStorage.getToken = function () {
        return sessionStorage.getItem(this.tokenKey);
    };
    SessionStorage.removeToken = function () {
        sessionStorage.removeItem(this.tokenKey);
    };
    SessionStorage.saveUserName = function (userName) {
        sessionStorage.setItem(this.userNameKey, userName);
    };
    SessionStorage.saveUserAvatar = function (avatarUrl) {
        sessionStorage.setItem(this.avatarKey, avatarUrl);
    };
    SessionStorage.getUserName = function () {
        return sessionStorage.getItem(this.userNameKey);
    };
    SessionStorage.removeUserName = function () {
        sessionStorage.removeItem(this.userNameKey);
    };
    SessionStorage.getUserAvatar = function () {
        return sessionStorage.getItem(this.avatarKey);
    };
    SessionStorage.removeUserAvatar = function () {
        sessionStorage.removeItem(this.avatarKey);
    };
    SessionStorage.saveRole = function (role) {
        sessionStorage.setItem(this.roleKey, role);
    };
    SessionStorage.getRole = function () {
        return sessionStorage.getItem(this.roleKey);
    };
    SessionStorage.removeRole = function () {
        sessionStorage.removeItem(this.roleKey);
    };
    SessionStorage.tokenKey = "accessToken";
    SessionStorage.userNameKey = "userName";
    SessionStorage.avatarKey = "avatar";
    SessionStorage.roleKey = "role";
    return SessionStorage;
}());
exports.SessionStorage = SessionStorage;
//# sourceMappingURL=session-storage.js.map