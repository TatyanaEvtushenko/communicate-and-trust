import { Component } from '@angular/core';
import { AccountService } from '../../services/account-service/account.service';
import { AuthorizedUserService } from '../../services/authorized-user-service/authorized-user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private accountService: AccountService, private userService: AuthorizedUserService) {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  signOut() {
    this.accountService.signOut().subscribe(this.userService.removeUserData, this.userService.removeUserData);
  }
}
