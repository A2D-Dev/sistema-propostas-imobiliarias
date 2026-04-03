import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // 👈 IMPORTANTE
import { ClienteService } from '../../../../core/services/cliente.service';
import { RouterModule } from '@angular/router';
import { DocumentoPipe } from '../../../../shared/pipes/documento.pipe';
import { Cliente } from '../../../../core/models/cliente.model';

@Component({
  selector: 'app-lista-clientes',
  standalone: true, // 👈 MUITO IMPORTANTE
  imports: [CommonModule, RouterModule, DocumentoPipe], // 👈 AQUI RESOLVE *ngFor, *ngIf
  templateUrl: './lista-clientes.component.html',
  styleUrls: ['./lista-clientes.component.css'] // 👈 ESSA LINHA
})
export class ListaClientesComponent implements OnInit {

  clientes: Cliente[] = [];

  carregando = true;
  erro = false;

  constructor(private clienteService: ClienteService) {}

  ngOnInit(): void {
    this.carregarClientes();
  }

  carregarClientes() {
    this.clienteService.getClientes().subscribe({
      next: (dados) => {
        this.clientes = dados;
        this.erro = false;
        this.carregando = false;
      },
      error: () => {
        this.erro = true;
        this.carregando = false;
      }
    });
  }
}