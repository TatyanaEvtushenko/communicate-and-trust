import { Component, OnInit } from '@angular/core';
import { WebcamImage, WebcamInitError, WebcamUtil } from 'ngx-webcam';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { TrainingSetup } from '../../models/training/training-setup';
import { TrainingResults } from "../../models/training/training-results";
import { SessionStorage } from "../../utils/session-storage";
import { TrainingService } from '../../services/training-service/training.service';

@Component({
  selector: 'training-page',
  templateUrl: './training-page.component.html',
  styleUrls: ['./training-page.component.css']
})
export class TrainingPageComponent implements OnInit {
  public sources: string[] = [];
  public isStart: boolean = false;
  public selectedEmotion: string = '';
  public errorMessage: string = '';
  public isWebcamToggled = true;
  public isContentLoaded = false;
  public trainingResults: TrainingResults = null;
  private trigger: Subject<void> = new Subject<void>();

  constructor(private trainingService: TrainingService) { }

  ngOnInit() {
    this.trainingService.getTrainingSession(SessionStorage.getUserName()).subscribe((result) => {
      this.isContentLoaded = true;
      if (!result) {
        this.isStart = false;
        return;
      }

      this.isStart = true;
      this.trainingResults = result;
      this.sources = this.trainingResults.sources;
    }, error => console.log(error));
  }

  start() {
    if (!this.selectedEmotion) {
      this.errorMessage = 'Please select emotion type of uploaded source!';
      return;
    }

    if (!this.sources || this.sources.length === 0) {
      this.errorMessage = 'Please upload any source to start training session!';
      return;
    }

    this.errorMessage = '';
    this.isStart = true;
    var trainingSetup = new TrainingSetup();
    trainingSetup.selectedEmotion = this.selectedEmotion;
    trainingSetup.sources = this.sources;
    trainingSetup.userName = SessionStorage.getUserName();
    trainingSetup.startDate = new Date(Date.now());
    this.trainingService.setupTrainingSession(trainingSetup).subscribe(() => {
      window.location.reload();
    }, error => console.log(error));
  }

  selectEmotion(emotion) {
    this.selectedEmotion = emotion;
  }

  toggleWebcamAndTakeSnapshot() {
    this.trigger.next();
  }

  handleImage(webcamImage: WebcamImage): void {
    this.sources.push(webcamImage.imageAsDataUrl);
  }

  clearImage(source) {
    this.sources = this.sources.filter((value) => {
      return value !== source;
    });
  }

  getFiles(event) {
    let files = event.target.files;
    for (var file of files) {
      this.getBase64(file).then(
        data => {
          this.sources.push(data);
        }
      );
    }
  }

  getBase64(file) {
    return new Promise<string>((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result);
      reader.onerror = error => reject(error);
    });
  }

  getEndDate(): string {
    let start = new Date(this.trainingResults.startDate);
    let now = new Date(Date.now());
    let otherPercents = 100 - this.trainingResults.percents;
    let difference = (now.getTime() - start.getTime()) * otherPercents / this.trainingResults.percents / 60000;
    let hours = Math.floor(difference / 60);
    let minutes = Math.round(difference - hours * 60);

    if (hours === 0) {
      return `${minutes}m`;
    }

    return `${hours}h ${minutes}m`;
  }

  get triggerObservable(): Observable<void> {
    return this.trigger.asObservable();
  }

}
