import { Component } from '@angular/core';
import { AuthorizedUserService } from '../services/authorized-user-service/authorized-user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  isVisibleNav = false;

  constructor() {
    this.isVisibleNav = AuthorizedUserService.isAuthorized;
  }
}
