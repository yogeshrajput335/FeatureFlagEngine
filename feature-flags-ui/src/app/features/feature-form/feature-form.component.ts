import { Component, OnInit } from '@angular/core';
import { FeatureFlagService, FeatureFlag } from '../../core/feature-flag.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
 selector: 'app-feature-form',
  imports: [FormsModule,CommonModule],
  standalone:true,
  templateUrl: './feature-form.component.html',
  styleUrl: './feature-form.component.css'
})
export class FeatureFormComponent implements OnInit {
  feature: FeatureFlag = { key: '', enabled: false, description: '' };
  id?: string;

  constructor(
    private service: FeatureFlagService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;
    if (this.id) {
      this.service.get(this.id).subscribe(f => this.feature = f);
    }
  }

  save(form: NgForm) {
    if (this.id) {
      this.service.update(this.id, this.feature).subscribe(() => this.router.navigate(['/features']));
    } else {
      this.service.create(this.feature).subscribe(() => this.router.navigate(['/features']));
    }
  }
}
