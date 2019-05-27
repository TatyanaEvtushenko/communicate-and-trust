import { Component, OnInit } from '@angular/core';
import { Session } from "../../models/session/session";
import { SessionService } from "../../services/session-service/session.service";
import { SessionStorage } from "../../utils/session-storage";

@Component({
  selector: 'sessions',
  templateUrl: './sessions.component.html',
  styleUrls: ['./sessions.component.css']
})
export class SessionsComponent implements OnInit {
  public sessions: Session[];

  constructor(private sessionService: SessionService) { }

  ngOnInit() {
    this.sessionService.getSessions(SessionStorage.getUserName()).subscribe((result) => {
      this.sessions = result;
    });
  }

  getOverall(session: Session): string {
    let start = new Date(session.startDate);
    let end = new Date(session.endDate);
    let difference = (end.getTime() - start.getTime()) / 60000;
    let hours = Math.floor(difference / 60);
    let minutes = Math.round(difference - hours * 60);

    if (hours === 0) {
      return `${minutes}m`;
    }

    return `${hours}h ${minutes}m`;
  }

  openSource(sourceString: string) {
    var newTab = window.open();
    newTab.document.body.innerHTML = `<img src='${sourceString}'>`;
  }

  openLogs(logs: string[]) {
    let text = '';
    for (let log of logs) {
      text = text + `<p># ${log}</p>`;
    }
    var newTab = window.open();
    newTab.document.body.innerHTML = text;
  }

}
