import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class FeatureService {
  constructor(private http: HttpClient) {}

  evaluate(req: any) {
    return this.http.post<{ enabled: boolean }>(
      'http://localhost:5190/api/evaluate',
      req
    );
  }
}
