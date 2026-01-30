import { Component } from '@angular/core';
import { FeatureService } from '../../core/feature.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-feature-evaluate',
  imports: [CommonModule, FormsModule],
  standalone:true,
  templateUrl: './feature-evaluate.component.html',
  styleUrl: './feature-evaluate.component.css'
})
export class FeatureEvaluateComponent {

  constructor(private service :FeatureService){}

  featureKey: string = '';
  userId: string = '';
  groups: string = '';
  region: string = '';

  result: boolean | null = null;

  evaluate() {
    this.service.evaluate({
      featureKey: this.featureKey,
      userId: this.userId,
      groupIds: this.groups?.split(','),
      region: this.region
    }).subscribe(r => this.result = r.enabled);
  }

}
