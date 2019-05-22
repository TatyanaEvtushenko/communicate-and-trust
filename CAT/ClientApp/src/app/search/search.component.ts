import { Component, Inject } from '@angular/core';
import { User } from '../../models/user/User';
import { UserService } from '../../services/user-service/user.service';

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
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
    //this.searchString = '';
    //this.users = null;
    //this.userService.getTopTenUsers().subscribe(result => {
    //  this.users = result;
    //  this.searchResultActive = false;
    //}, error => console.error(error));


    this.searchString = 'captain';
    var user1 = new User();
    user1.firstName = "Captain";
    user1.secondName = "America";
    user1.avatar = "https://www.screengeek.net/wp-content/uploads/2018/09/avengers-4-captain-america.jpg";
    user1.name = "caprica2828";
    user1.isOnline = true;
    var user2 = new User();
    user2.firstName = "Captain";
    user2.secondName = "Marvel";
    user2.avatar = "https://cdn.vox-cdn.com/thumbor/YW9sjpfa6EVHixAqKr-ndgX2pf0=/0x0:1400x1400/920x613/filters:focal(602x377:826x601):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/63147262/captainmarvelbrielarson.0.jpg";
    user2.name = "goodgirl999";
    user2.isOnline = false;

    this.users = [user1, user2];
  }

}
