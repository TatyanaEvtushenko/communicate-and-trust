import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'training-page',
  templateUrl: './training-page.component.html',
  styleUrls: ['./training-page.component.css']
})
export class TrainingPageComponent implements OnInit {
  public sources: string[];
  public isStart: boolean = false;

  constructor() { }

  ngOnInit() {
    this.sources = [
      'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1ZTrPDgdIgQ0nEwy_2aqIsxG09XM1soT_Mr1_q4xR6pF2kjb-',
      'https://previews.123rf.com/images/avemario/avemario1603/avemario160300315/54165121-surprise-astonished-woman-closeup-portrait-woman-looking-surprised-in-full-disbelief-wide-open-mouth.jpg',
      'https://www.cbc.ca/natureofthings/content/images/blog/Universal_Expression_Surprise.jpg',
      'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-V6MsDsvHLCGGCRjtECVf1LICszsbwEI4vwxqJOL3GXXdHD-W',
      'https://www.researchgate.net/profile/Ziduan_Xu/publication/256443644/figure/fig9/AS:297904574091273@1448037393925/Surprise-emotion-as-cited-in-Hadnagy-2011.png',
      'https://i.ytimg.com/vi/vTaRYDZ3LJI/maxresdefault.jpg',
      'https://www.meme-arsenal.com/memes/dde056003e6eac44a482b3eae43f2d4a.jpg',
      'https://p.motionelements.com/stock-video/people/me11573763-little-cute-caucasian-girl-smiling-showing-emotion-surprise-ukraine-4k-a0055.jpg'
    ];
  }

  clickIsStart() {
    this.isStart = true;
  }

}
