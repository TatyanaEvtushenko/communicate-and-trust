import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { Observable } from 'rxjs';
import { TestResult } from "../../models/test/test-result";

@Injectable()
export class TestService {

  constructor(private http: HttpService) {
  }

  saveTestResults(result: TestResult): Observable<void> {
    this.http.controllerName = 'test';
    return this.http.post('saveTestResults', result);
  }

}
