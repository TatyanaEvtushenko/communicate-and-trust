import { Component, Input } from '@angular/core';
import { User } from '../../models/user/User';

@Component({
  selector: 'user-list',
  templateUrl: './user-list.component.html'
})
export class UserListComponent {
  @Input() public users: User[];
}
