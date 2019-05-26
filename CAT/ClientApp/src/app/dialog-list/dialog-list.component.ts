import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DialogService } from '../../services/dialog-service/dialog.service';
import { DialogPreview } from "../../models/dialog/dialogPreview";
import { Message } from "../../models/dialog/message";
import { SessionStorage } from "../../utils/session-storage";

@Component({
  selector: 'dialog-list',
  templateUrl: './dialog-list.component.html',
  styleUrls: ['./dialog-list.component.css']
})
export class DialogListComponent implements OnInit {
  public dialogs: DialogPreview[];
  public searchString: string;
  public currentUserAvatar: string;
  public currentUserName: string;

  constructor(
    private dialogService: DialogService,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.currentUserAvatar = SessionStorage.getUserAvatar();
    this.currentUserName = SessionStorage.getUserName();
    this.dialogService.getCurrentUserDialogs(this.currentUserName).subscribe(result => {
      this.dialogs = result;
    }, error => console.error(error));
  }

  updateDialogsList(newValue: string) {
    this.searchString = newValue;
  }

  openUserDialog(login: string) {
    this.router.navigate(['/dialog', login]);
  }
}
