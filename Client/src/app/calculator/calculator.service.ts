import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { endpoints } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class CalculatorService {
  private baseUrl: string = `${endpoints.server}/calculate`;
  constructor(private http: HttpClient) { }
  public calculate(scheme: string): Observable<any> { return this.http.get(`${this.baseUrl}/${scheme}`); }
}
