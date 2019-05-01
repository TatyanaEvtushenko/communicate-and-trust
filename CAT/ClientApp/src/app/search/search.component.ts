import { Component, Inject } from '@angular/core';
import { User } from '../../models/user/User';
import { UserService } from '../../services/user-service/user.service';

@Component({
  selector: 'search',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public users: User[];
  public searchString: string;
  public searchResultActive: boolean;

  constructor(private userService: UserService) {
    this.searchReset();
  }

  updateUsersList(newValue: string) {
    this.searchString = newValue;
    if (newValue.length < 2) {
      return;
    }

    this.users = null;
    this.userService.getUsersByString(newValue).subscribe(result => {
      this.users = result;
      this.searchResultActive = true;
    }, error => console.error(error));
  }

  searchReset() {
    this.searchString = '';
    this.users = null;
    this.userService.getTopTenUsers().subscribe(result => {
      this.users = result;
      this.searchResultActive = false;
    }, error => console.error(error));
  }

}
