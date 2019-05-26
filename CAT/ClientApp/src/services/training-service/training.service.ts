import { Injectable } from '@angular/core';
import { HttpService } from '../http-service/http.service';
import { Observable } from 'rxjs';
import { TrainingSetup } from "../../models/training/training-setup";
import { TrainingResults } from "../../models/training/training-results";

@Injectable()
export class TrainingService {

  constructor(private http: HttpService) {
  }

  setupTrainingSession(setup: TrainingSetup): Observable<void> {
    this.http.controllerName = 'training';
    return this.http.post('setupTrainingSession', setup);
  }

  getTrainingSession(userName: string): Observable<TrainingResults> {
    this.http.controllerName = 'training';
    return this.http.get(`getTrainingSession?userName=${userName}`);
  }

}
