import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account-service/account.service';
import { AuthorizedUserService } from '../../services/authorized-user-service/authorized-user.service';
import { SessionStorage } from "../../utils/session-storage";
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isAdmin: boolean = false;

  constructor(
    private accountService: AccountService,
    private userService: AuthorizedUserService,
    private router: Router) {
  }

  ngOnInit() {
    this.isAdmin = SessionStorage.getRole() == 'Admin';
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  signOut() {
    this.accountService.signOut().subscribe(() => {
      this.userService.removeUserData();
      window.location.reload();
    }, () => {
      this.userService.removeUserData();
      window.location.href = "/";
    });
  }
}
