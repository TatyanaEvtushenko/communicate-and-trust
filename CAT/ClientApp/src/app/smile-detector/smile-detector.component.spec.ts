import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SmileDetectorComponent } from './smile-detector.component';

describe('SmileDetectorComponent', () => {
  let component: SmileDetectorComponent;
  let fixture: ComponentFixture<SmileDetectorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SmileDetectorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SmileDetectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
