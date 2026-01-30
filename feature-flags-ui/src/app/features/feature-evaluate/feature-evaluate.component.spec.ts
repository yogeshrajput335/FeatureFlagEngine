import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeatureEvaluateComponent } from './feature-evaluate.component';

describe('FeatureEvaluateComponent', () => {
  let component: FeatureEvaluateComponent;
  let fixture: ComponentFixture<FeatureEvaluateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FeatureEvaluateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeatureEvaluateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
