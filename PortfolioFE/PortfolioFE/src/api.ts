import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private API_BASE_URL = 'https://localhost:7009/User';

  constructor(private http: HttpClient) {}

  create(command: CreateUserCommandRequest): Observable<any> {
    return this.http.post(`${this.API_BASE_URL}/create`, command);
  }

  getAll(): Observable<any> {
    return this.http.get(`${this.API_BASE_URL}/get-all`);
  }

  getById(userId: number): Observable<any> {
    const params = new HttpParams().set('userId', userId.toString());
    return this.http.get(`${this.API_BASE_URL}/get`, { params });
  }
}

export interface CreateUserCommandRequest {
  firstName: string;
  lastName: string;
  quote: string;
  email: string;
}
