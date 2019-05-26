import { Component, OnInit } from '@angular/core';
import { EmotionService } from '../../services/emotion-service/emotion.service';
import { TestService } from '../../services/test-service/test.service';
import { WebcamImage, WebcamInitError, WebcamUtil } from 'ngx-webcam';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { TestResult } from '../../models/test/test-result';
import { SessionStorage } from "../../utils/session-storage";

@Component({
  selector: 'test-page',
  templateUrl: './test-page.component.html',
  styleUrls: ['./test-page.component.css']
})
export class TestPageComponent implements OnInit {
  public isStart: boolean = false;
  public source: string = '';
  public isWebcamToggled = true;
  public isError = false;
  public testResult: TestResult = null;
  public errorMessage = '';
  public selectedEmotion = '';
  private trigger: Subject<void> = new Subject<void>();

  constructor(
    private emotionService: EmotionService,
    private testService: TestService
  ) { }

  ngOnInit() {
  }

  start() {
    if (!this.selectedEmotion) {
      this.showError('Please select emotion type of uploaded source!');
      return;
    }

    if (!this.source) {
      this.showError('Please upload any source to start test session!');
      return;
    }

    this.isError = false;
    this.isStart = true;
    this.emotionService.getEmotion(this.source).subscribe((result: any) => {
      if (result.length !== 1) {
        this.showError('Please check that uploaded source containts only ONE face!');
        return;
      }

      var recognitionResult = this.emotionService.getEmotionResults(result);
      var testResult = new TestResult();
      testResult.source = this.source;
      testResult.selectedEmotion = this.selectedEmotion;
      testResult.resultEmotion = recognitionResult[0];
      testResult.userName = SessionStorage.getUserName();
      testResult.emotions = result[0].faceAttributes.emotion;
      this.testService.saveTestResults(testResult).subscribe(() => {
        this.testResult = testResult;
      });
    }, error => console.log(error));
  }

  reset() {
    this.source = '';
    this.isStart = false;
    this.testResult = null;
    this.isError = false;
  }

  handleImage(webcamImage: WebcamImage): void {
    this.source = webcamImage.imageAsDataUrl;
  }

  toggleWebcamAndTakeSnapshot() {
    this.trigger.next();
  }

  clearImage() {
    this.source = '';
  }

  getFiles(event) {
    let file = event.target.files[0];
    this.getBase64(file).then(
      data => {
        this.source = data;
      }
    );
  }

  showError(text) {
    this.isStart = false;
    this.testResult = null;
    this.isError = true;
    this.errorMessage = text;
  }

  selectEmotion(emotion) {
    this.selectedEmotion = emotion;
  }

  getClass(emotion: string) {
    let isResultValid = this.testResult.resultEmotion === this.testResult.selectedEmotion;
    if (this.testResult.resultEmotion === emotion) {
      return isResultValid ? "valid" : "invalid";
    }

    return "";
  }

  getValue(value: number) {
    if (value === 1) {
      return Math.random() * (100 - 70) + 70;
    }

    if (value === 0) {
      return Math.random() * 4;
    }

    return value * 100;
  }

  getBase64(file) {
    return new Promise<string>((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result);
      reader.onerror = error => reject(error);
    });
  }

  get triggerObservable(): Observable<void> {
    return this.trigger.asObservable();
  }

}
