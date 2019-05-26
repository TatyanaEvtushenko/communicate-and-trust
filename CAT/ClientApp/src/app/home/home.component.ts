import { Component } from '@angular/core';
import { AuthorizedUserService } from '../../services/authorized-user-service/authorized-user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  isVisibleAuthForm = false;

  constructor() {
    this.isVisibleAuthForm = !AuthorizedUserService.isAuthorized;
  }
}
