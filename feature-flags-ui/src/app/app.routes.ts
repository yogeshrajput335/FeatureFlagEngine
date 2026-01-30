import { Routes } from '@angular/router';
import { FeatureEvaluateComponent } from './features/feature-evaluate/feature-evaluate.component';
import { FeatureListComponent } from './features/feature-list/feature-list.component';
import { FeatureFormComponent } from './features/feature-form/feature-form.component';

export const routes: Routes = [
  { path: '', redirectTo: 'features', pathMatch: 'full' },
  { path: 'features', component: FeatureListComponent },
  { path: 'features/new', component: FeatureFormComponent },
  { path: 'features/edit/:id', component: FeatureFormComponent },
  { path: 'evaluate', component: FeatureEvaluateComponent }
];
