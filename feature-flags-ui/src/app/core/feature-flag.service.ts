import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface FeatureFlag {
  id?: string;
  key: string;
  enabled: boolean;
  description?: string;
}

@Injectable({ providedIn: 'root' })
export class FeatureFlagService {
  private apiUrl = 'http://localhost:5190/api/FeatureFlags';

  constructor(private http: HttpClient) {}

  getAll(): Observable<FeatureFlag[]> {
    return this.http.get<FeatureFlag[]>(this.apiUrl);
  }

  get(id: string): Observable<FeatureFlag> {
    return this.http.get<FeatureFlag>(`${this.apiUrl}/${id}`);
  }

  create(flag: FeatureFlag): Observable<FeatureFlag> {
    return this.http.post<FeatureFlag>(this.apiUrl, flag);
  }

  update(id: string, flag: FeatureFlag): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, flag);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
