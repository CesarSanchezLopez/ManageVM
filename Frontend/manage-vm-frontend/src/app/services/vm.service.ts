import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Vm } from '../models/vm.model'; // Ajusta la ruta
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VmService {
  private apiUrl = `${environment.apiUrl}/vm`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Vm[]> {
    return this.http.get<Vm[]>(this.apiUrl).pipe(
      map(res => res || []),
      catchError(this.handleError)
    );
  }

  getById(id: number): Observable<Vm> {
    return this.http.get<Vm>(`${this.apiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  create(vm: Vm): Observable<Vm> {
    return this.http.post<Vm>(this.apiUrl, vm).pipe(
      catchError(this.handleError)
    );
  }

  update(id: number, vm: Vm): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, vm).pipe(
      catchError(this.handleError)
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMsg = 'Error desconocido. Intente más tarde.';

    if (error.status === 0) {
      errorMsg = 'No se pudo conectar con el servidor.';
    } else if (error.status === 401) {
      errorMsg = 'Sesión expirada o token inválido.';
    } else if (error.status === 403) {
      errorMsg = 'No tiene permisos para realizar esta acción.';
    } else if (error.status === 404) {
      errorMsg = 'El recurso solicitado no existe.';
    } else if (error.error?.message) {
      errorMsg = error.error.message;
    }

    return throwError(() => new Error(errorMsg));
  }
}