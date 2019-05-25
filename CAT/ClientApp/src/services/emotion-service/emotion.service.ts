import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable()
export class EmotionService {
  private url: string = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";
  private key: string = "9d6206dd94584320aeb39aec4bc7f75b";

  constructor(private http: HttpClient) {
  }

  getEmotion(base64String: string): Observable<any> {
    const headers = this.getHeaders(this.key);
    const params = this.getParams();
    const blob = this.makeblob(base64String);
    return this.http.post(
      this.url,
      blob,
      {
        params,
        headers
      });
  }

  getEmotionResults(results: any): string[] {
    let resultArray = [];
    for (let result of results) {
      var emotion = result.faceAttributes.emotion;
      var arr = [
        emotion.anger,
        emotion.contempt,
        emotion.disgust,
        emotion.fear,
        emotion.happiness,
        emotion.neutral,
        emotion.sadness,
        emotion.surprise
      ];
      let i = arr.indexOf(Math.max(...arr));
      resultArray.push(Object.keys(emotion)[i]);
    }

    return resultArray;
  }

  mapEmotion(str: string) {
    switch (str) {
    case "anger":
      return "😠";
    case "contempt":
      return "😕";
    case "disgust":
      return "🤮";
    case "fear":
      return "😱";
    case "happiness":
      return "😃";
    case "neutral":
      return "😐";
    case "sadness":
      return "😥";
    case "surprise":
      return "😲";
    default:
      return "😐";
    }
  }

  private getHeaders(subscriptionKey: string) {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/octet-stream');
    headers = headers.set('Ocp-Apim-Subscription-Key', subscriptionKey);

    return headers;
  }

  private getParams() {
    const httpParams = new HttpParams()
      .set('returnFaceId', 'true')
      .set('returnFaceLandmarks', 'false')
      .set(
        'returnFaceAttributes',
        'age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise'
      );

    return httpParams;
  }

  private makeblob(dataURL) {
    const BASE64_MARKER = ';base64,';
    const parts = dataURL.split(BASE64_MARKER);
    const contentType = parts[0].split(':')[1];
    const raw = window.atob(parts[1]);
    const rawLength = raw.length;
    const uInt8Array = new Uint8Array(rawLength);

    for (let i = 0; i < rawLength; ++i) {
      uInt8Array[i] = raw.charCodeAt(i);
    }

    return new Blob([uInt8Array], { type: contentType });
  }

}
