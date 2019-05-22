import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'test-page',
  templateUrl: './test-page.component.html',
  styleUrls: ['./test-page.component.css']
})
export class TestPageComponent implements OnInit {
  public isStart: boolean = false;
  public source: string = '';

  constructor() { }

  ngOnInit() {
    this.source =
      'https://i.ytimg.com/vi/vTaRYDZ3LJI/maxresdefault.jpg';
  }

  clickIsStart() {
    this.isStart = true;
  }

}
