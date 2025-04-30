import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Vm } from '../models/vm.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class VmService {
  private apiUrl = 'https://localhost:7270/api/vm'; // Ajusta según tu backend

  constructor(private http: HttpClient) {}

  getAll(): Observable<Vm[]> {
    return this.http.get<Vm[]>(this.apiUrl);
  }

  getById(id: number): Observable<Vm> {
    return this.http.get<Vm>(`${this.apiUrl}/${id}`);
  }

  create(vm: Vm): Observable<Vm> {
    return this.http.post<Vm>(this.apiUrl, vm);
  }

  update(id: number, vm: Vm): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, vm);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}