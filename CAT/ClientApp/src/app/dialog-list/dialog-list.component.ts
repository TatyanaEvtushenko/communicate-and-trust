import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DialogService } from '../../services/dialog-service/dialog.service';
import { DialogPreview } from "../../models/dialog/dialogPreview";
import { Message } from "../../models/dialog/message";

@Component({
  selector: 'dialog-list',
  templateUrl: './dialog-list.component.html',
  styleUrls: ['./dialog-list.component.css']
})
export class DialogListComponent implements OnInit {
  public dialogs: DialogPreview[];
  public searchString: string;
  public currentUserAvatar: string;

  constructor(
    private dialogService: DialogService,
    private router: Router
  ) {
    this.currentUserAvatar = "https://sun2.cosmostv-by-minsk.userapi.com/c850720/v850720123/b29bd/ZeZQRRpKczo.jpg";
  }

  ngOnInit() {
    var dialogPreview1 = new DialogPreview();
    dialogPreview1.firstName = "Captain";
    dialogPreview1.secondName = "America";
    dialogPreview1.login = "caprica2828";
    dialogPreview1.isOnline = true;
    dialogPreview1.avatarUrl =
      "https://www.screengeek.net/wp-content/uploads/2018/09/avengers-4-captain-america.jpg";
    var message1 = new Message();
    message1.author = "caprica2828";
    message1.postDate = new Date("May 1, 2019 11:22:00");
    message1.text = "Видела мем про nigatony? Ор выше гор :О";
    message1.isReaden = false;
    dialogPreview1.lastMessage = message1;

    var dialogPreview2 = new DialogPreview();
    dialogPreview2.firstName = "Iron";
    dialogPreview2.secondName = "Man";
    dialogPreview2.login = "tonyStarkTheStar";
    dialogPreview2.isOnline = false;
    dialogPreview2.avatarUrl =
      "https://www.hindustantimes.com/rf/image_size_960x540/HT/p2/2019/04/19/Pictures/_1d701ffe-62a7-11e9-b92f-deef78e36bd1.jpg";
    var message2 = new Message();
    message2.author = "";
    message2.postDate = new Date("April 30, 2019 19:44:00");
    message2.text = "Мне интересно: как ты до сих пор терпишь кэпа?";
    message2.isReaden = true;
    dialogPreview2.lastMessage = message2;

    var dialogPreview3 = new DialogPreview();
    dialogPreview3.firstName = "Black";
    dialogPreview3.secondName = "Widow";
    dialogPreview3.login = "наташкаРомашка";
    dialogPreview3.isOnline = false;
    dialogPreview3.avatarUrl =
      "https://am24.akamaized.net/tms/cnt/uploads/2018/05/black-widow-scarlett-johansson-marvel-the-avengers.jpg";
    var message3 = new Message();
    message3.author = "";
    message3.postDate = new Date("April 30, 2019 16:20:00");
    message3.text = "Я слышала ты отхватила в последнем бою... Как себя чувствуешь?";
    message3.isReaden = false;
    dialogPreview3.lastMessage = message3;

    var dialogPreview4 = new DialogPreview();
    dialogPreview4.firstName = "Amaizing";
    dialogPreview4.secondName = "HULK";
    dialogPreview4.login = "crushcrushcrush";
    dialogPreview4.isOnline = true;
    dialogPreview4.avatarUrl =
      "https://www.hindustantimes.com/rf/image_size_960x540/HT/p2/2018/06/15/Pictures/_1caf1900-7098-11e8-bbf6-b72314b60444.jpg";
    var message4 = new Message();
    message4.author = "crushcrushcrush";
    message4.postDate = new Date("April 30, 2019 10:58:00");
    message4.text = "КРУШИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИТЬ";
    message4.isReaden = true;
    dialogPreview4.lastMessage = message4;

    this.dialogs = [
      dialogPreview1,
      dialogPreview2,
      dialogPreview3,
      dialogPreview4
    ];
  }

  updateDialogsList(newValue: string) {
    this.searchString = newValue;
  }

  openUserDialog(login: string) {
    this.router.navigate(['/dialog', login]);
  }
}
