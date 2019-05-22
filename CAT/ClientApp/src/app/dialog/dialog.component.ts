import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DialogService } from '../../services/dialog-service/dialog.service';
import { Dialog } from "../../models/dialog/dialog";
import { Message } from "../../models/dialog/message";

@Component({
  selector: 'users-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {
  public name: string;
  public dialog: Dialog;
  public emotionRecognotion: string;
  public emotionRecognotionTitle: string;

  constructor(
    private route: ActivatedRoute,
    private dialogService: DialogService
  ) {
    this.emotionRecognotion = "<div>" +
      "<img src='https://previews.123rf.com/images/kurhan/kurhan1108/kurhan110800256/10304233-happy-people-.jpg'/>" +
      "<p>Is it <b>JOY</b>?</p>" +
      "<a class='btn btn-success'>Yes</a>" +
      "<a class='btn btn-danger'>No</a>" +
      "</div>";
    this.emotionRecognotionTitle = "<b>Emotion recognition</b>" +
      "<a type='button' id='close' class='close' onclick='$('#example').popover('hide');'>&times;</a>";
  }

  ngOnInit() {
    this.name = this.route.snapshot.paramMap.get('userName');
    //this.dialogService.getDialogWithUser(this.name).subscribe(result => {
    //  this.dialog = result;
    //}, error => console.error(error));

    var message1 = new Message();
    message1.author = this.name;
    message1.postDate = new Date("May 1, 2019 11:13:00");
    message1.text = "Привет! Как твои успехи с учебой?";
    message1.isReaction = false;
    message1.avatarUrl = "https://www.screengeek.net/wp-content/uploads/2018/09/avengers-4-captain-america.jpg";

    var message2 = new Message();
    message2.author = "";
    message2.postDate = new Date("May 1, 2019 11:14:00");
    message2.text = "😊";
    message2.isReaction = true;
    message2.avatarUrl = "https://sun2.cosmostv-by-minsk.userapi.com/c850720/v850720123/b29bd/ZeZQRRpKczo.jpg";

    var message3 = new Message();
    message3.author = "";
    message3.postDate = new Date("May 1, 2019 11:15:00");
    message3.text = "Довольно неплохо, заканчиваю писать диплом! У тебя как жизнь?";
    message1.isReaction = false;
    message3.avatarUrl = "https://sun2.cosmostv-by-minsk.userapi.com/c850720/v850720123/b29bd/ZeZQRRpKczo.jpg";

    var message4 = new Message();
    message4.author = this.name;
    message4.postDate = new Date("May 1, 2019 11:16:00");
    message4.text = "😲";
    message4.isReaction = true;
    message4.avatarUrl = "https://www.screengeek.net/wp-content/uploads/2018/09/avengers-4-captain-america.jpg";

    var message5 = new Message();
    message5.author = this.name;
    message5.postDate = new Date("May 1, 2019 11:17:00");
    message5.text = "Круто! Рад за тебя😊😊😊";
    message5.isReaction = false;
    message5.avatarUrl = "https://www.screengeek.net/wp-content/uploads/2018/09/avengers-4-captain-america.jpg";

    var message6 = new Message();
    message6.author = this.name;
    message6.postDate = new Date("May 1, 2019 11:18:00");
    message6.text = "А мы вот тут с ребятами недавно войну бесконечности досняли... уже сходила в кино?";
    message6.isReaction = false;
    message6.avatarUrl = "https://www.screengeek.net/wp-content/uploads/2018/09/avengers-4-captain-america.jpg";

    var message7 = new Message();
    message7.author = "";
    message7.postDate = new Date("May 1, 2019 11:19:00");
    message7.text = "😭";
    message7.isReaction = true;
    message7.avatarUrl = "https://sun2.cosmostv-by-minsk.userapi.com/c850720/v850720123/b29bd/ZeZQRRpKczo.jpg";

    var message8 = new Message();
    message8.author = "";
    message8.postDate = new Date("May 1, 2019 11:20:00");
    message8.text = "Только вчера сходила, полна эмоций и грусти по героям 😭😭😭";
    message8.isReaction = false;
    message8.avatarUrl = "https://sun2.cosmostv-by-minsk.userapi.com/c850720/v850720123/b29bd/ZeZQRRpKczo.jpg";

    var message9 = new Message();
    message9.author = this.name;
    message9.postDate = new Date("May 1, 2019 11:21:00");
    message9.text = "😊";
    message9.isReaction = true;
    message9.avatarUrl = "https://www.screengeek.net/wp-content/uploads/2018/09/avengers-4-captain-america.jpg";

    var message10 = new Message();
    message10.author = this.name;
    message10.postDate = new Date("May 1, 2019 11:22:00");
    message10.text = "Видела мем про nigatony? Ор выше гор :О";
    message10.isReaction = false;
    message10.avatarUrl = "https://www.screengeek.net/wp-content/uploads/2018/09/avengers-4-captain-america.jpg";

    var message11 = new Message();
    message11.author = "";
    message11.postDate = new Date("May 1, 2019 11:23:00");
    message11.text = "😐";
    message11.isReaction = true;
    message11.avatarUrl = "https://sun2.cosmostv-by-minsk.userapi.com/c850720/v850720123/b29bd/ZeZQRRpKczo.jpg";

    var message12 = new Message();
    message12.author = "";
    message12.postDate = new Date("May 1, 2019 11:24:00");
    message12.text = "Нет, а что за он?";
    message12.isReaction = false;
    message12.avatarUrl = "https://sun2.cosmostv-by-minsk.userapi.com/c850720/v850720123/b29bd/ZeZQRRpKczo.jpg";

    this.dialog = new Dialog();
    this.dialog.messages = [
      message1, message2,
      message3, message4,
      message5, message6,
      message7, message8,
      message9, message10,
      message11, message12
    ];
    this.dialog.isOnline = true;
  }
}
