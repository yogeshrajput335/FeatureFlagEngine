import { Component, OnInit } from '@angular/core';
import { FeatureFlagService, FeatureFlag } from '../../core/feature-flag.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-feature-list',
  imports: [CommonModule, FormsModule],
  standalone:true,
  templateUrl: './feature-list.component.html',
  styleUrl: './feature-list.component.css'
})
export class FeatureListComponent implements OnInit {
  features: FeatureFlag[] = [];

  constructor(private service: FeatureFlagService, private router: Router) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.service.getAll().subscribe(f => this.features = f);
  }

  edit(id: string) {
    this.router.navigate(['/features/edit', id]);
  }

  delete(id: string) {
    this.service.delete(id).subscribe(() => this.load());
  }
}
