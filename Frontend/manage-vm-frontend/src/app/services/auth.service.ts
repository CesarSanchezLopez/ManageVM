import { HttpClient,HttpErrorResponse  } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { throwError, catchError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl =  `${environment.apiUrl}/token`;//'https://localhost:7270/api/token'; // tu API

  constructor(private http: HttpClient) {}

  login(email: string, password: string) {
    
    // return this.http.post<{ token: string }>(`${this.apiUrl}/login`, {
    //   email,
    //   password
    // });
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, {
      email,
      password
    }).pipe(
      catchError(this.handleError)
    );
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


  private handleError(error: HttpErrorResponse) {
    let errorMsg = 'Error inesperado. Intente más tarde.';

    if (error.status === 0) {
      errorMsg = 'No se pudo conectar con el servidor.';
    } else if (error.status === 401) {
      errorMsg = 'Credenciales inválidas o sesión expirada.';
    } 
    else if (error.status === 400) {
      errorMsg = 'No se pudo conectar con el servidor..';
    }
    else if (error.status === 403) {
      errorMsg = 'No tiene permisos suficientes para acceder.';
    } else if (error.status === 404) {
      errorMsg = 'Recurso no encontrado.';
    } else if (error.error?.message) {
      errorMsg = error.error.message;
    }

    return throwError(() => new Error(errorMsg));
  }
}