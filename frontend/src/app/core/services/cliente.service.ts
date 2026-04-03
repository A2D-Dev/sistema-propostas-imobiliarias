import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente.model';



@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private apiUrl = 'http://localhost:5008/api/clientes'; 
  // ⚠️ ajusta se sua porta for diferente

  constructor(private http: HttpClient) {}

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.apiUrl);
  }

  adicionarCliente(cliente: Cliente) {
    return this.http.post<Cliente>('http://localhost:5008/api/clientes', cliente);
  }  
}