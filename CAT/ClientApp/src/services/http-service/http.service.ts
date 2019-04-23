import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { SessionStorage } from "../../utils/session-storage";

@Injectable()
export class HttpService {

  controllerName: string;

  constructor(private http: HttpClient) {    
  }
  
  get(actionName: string): Observable<any> {
    let url = this.getDestinationUrl(actionName);
    let options = this.getRequestOptions();
    return this.http.get(url, options);
  }
  
  post(actionName: string, body: any): Observable<any> {
    let url = this.getDestinationUrl(actionName);
    let options = this.getRequestOptions();
    return this.http.post(url, body, options);
  }

  private getDestinationUrl(actionName: string): string {
    return `/api/${this.controllerName}/${actionName}`;
  }

  private getRequestOptions() {
    let token = SessionStorage.getToken();
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return { 
      headers: headers
    };
  }
  
}
