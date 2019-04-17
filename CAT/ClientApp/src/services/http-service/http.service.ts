import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable()
export class HttpService {

  controllerName: string;

  constructor(private http: HttpClient) {    
  }
  
  post(actionName: string, body: any): Observable<any> {
    let url = this.getDestinationUrl(actionName);
    return this.http.post(url, body);
  }

  private getDestinationUrl(actionName: string): string {
    return `/api/${this.controllerName}/${actionName}`;
  }
  
}
