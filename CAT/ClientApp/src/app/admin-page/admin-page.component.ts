import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit {
  public page:number = 0;

  constructor() { }

  ngOnInit() {
  }

  updatePageState(state: number) {
    this.page = state;
  }

}
