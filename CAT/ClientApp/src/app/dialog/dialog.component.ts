import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DialogService } from '../../services/dialog-service/dialog.service';
import { EmotionService } from '../../services/emotion-service/emotion.service';
import { Dialog } from "../../models/dialog/dialog";
import { EmotionResult } from "../../models/dialog/emotionResult";
import { Message } from "../../models/dialog/message";
import { SessionStorage } from "../../utils/session-storage";
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { WebcamImage, WebcamInitError, WebcamUtil } from 'ngx-webcam';

@Component({
  selector: 'users-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {
  public name: string;
  public dialog: Dialog;
  public messageText = "";
  public isPopoverActive = false;
  public isReaction = false;
  public showWebcam = false;
  public errors: WebcamInitError[] = [];
  public webcamImage: WebcamImage = null;
  public emotionResults: EmotionResult = null;
  private trigger: Subject<void> = new Subject<void>();
  private interval = null;

  constructor(
    private route: ActivatedRoute,
    private dialogService: DialogService,
    private emotionService: EmotionService
  ) {
  }

  ngOnInit() {
    let currentUserName = SessionStorage.getUserName();
    this.name = this.route.snapshot.paramMap.get('userName');
    this.dialogService.getDialogWithUser(this.name, currentUserName).subscribe(result => {
      let messagesAreReaden = false;
      for (let message of result.messages) {
        if (message.author === currentUserName) {
          message.author = "";
          message.avatarUrl = SessionStorage.getUserAvatar();
        } else {
          message.avatarUrl = result.avatar;
          if (!message.isRead && !messagesAreReaden) {
            this.dialogService.readAllMessages(currentUserName, this.name)
              .subscribe(result => {
                if (result) {
                  this.startReactionPopover();
                }
              },
                error => console.error(error));
            messagesAreReaden = true;
          }
        }
      }
      this.dialog = result;
      WebcamUtil.getAvailableVideoInputs().then((mediaDevices: MediaDeviceInfo[]) => { });
    }, error => console.error(error));
  }

  postMessage(text: string, isReaction: boolean) {
    var message = new Message();
    message.author = SessionStorage.getUserName();
    message.to = this.name;
    message.postDate = new Date(Date.now());
    message.text = text;
    message.isReaction = isReaction;
    this.dialogService.postMessage(message).subscribe((data: boolean) => {
      if (!data) {
        return;
      }
    });
    message.avatarUrl = SessionStorage.getUserAvatar();
    message.author = "";
    this.messageText = "";
    this.dialog.messages.push(message);
  }

  startReactionPopover() {
    this.isReaction = true;
    this.triggerPopover(1000);
    setTimeout(() => {
      this.postMessage(this.getEmojiesText(), true);
      this.hidePopover();
      this.isReaction = false;
    }, 7000);
  }

  triggerPopover(milliseconds: number) {
    this.isPopoverActive = !this.isPopoverActive;

    if (this.isPopoverActive) {
      this.interval = setInterval(() => {
        this.trigger.next();
      }, milliseconds);
    } else {
      clearInterval(this.interval);
      this.emotionResults = null;
    }
  }

  hidePopover() {
    this.isPopoverActive = false;
    clearInterval(this.interval);
    this.emotionResults = null;
  }

  handleImage(webcamImage: WebcamImage): void {
    this.webcamImage = webcamImage;
    this.emotionService.getEmotion(webcamImage.imageAsDataUrl).subscribe((result: any) => {
      this.emotionResults = new EmotionResult();
      if (result.length === 0) {
        this.emotionResults.isFailedToRecognize = true;
      } else {
        this.emotionResults.emotionStrings = this.emotionService.getEmotionResults(result);
      }
    });
  }

  getEmotionResultString() {
    return this.emotionResults.emotionStrings.join(' | ');
  }

  setEmotionResultToMessage() {
    this.messageText = this.messageText + this.getEmojiesText();
    this.hidePopover();
  }

  getEmojiesText() {
    if (!this.emotionResults) {
      return this.emotionService.mapEmotion("neutral");
    }

    return this.emotionResults.emotionStrings.map(x => this.emotionService.mapEmotion(x)).join();
  }

  clearEmotionResult() {
    this.emotionResults = null;
  }

  get triggerObservable(): Observable<void> {
    return this.trigger.asObservable();
  }
}
