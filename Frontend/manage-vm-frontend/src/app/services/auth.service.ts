import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl =  `${environment.apiUrl}/token`;//'https://localhost:7270/api/token'; // tu API
  //private apiUrl =  'https://localhost:7270/api/token'; // tu API
  constructor(private http: HttpClient) {}

  login(email: string, password: string) {
    console.log(`${this.apiUrl}/login`);
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, {
      email,
      password
    });
  }

  saveToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}