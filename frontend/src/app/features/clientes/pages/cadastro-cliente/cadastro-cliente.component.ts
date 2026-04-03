import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ClienteService } from '../../../../core/services/cliente.service';
import { Cliente } from '../../../../core/models/cliente.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cadastro-cliente',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './cadastro-cliente.component.html',
  styleUrl: './cadastro-cliente.component.css'
})

export class CadastroClienteComponent {
  cliente: Cliente = {
  nome: '',
  documento: '',
  tipoPessoa: 'PF'
  };

  constructor(
    private clienteService: ClienteService,
    private router: Router
  ) {}

  formatarDocumento() {

    // remove tudo que não é número
    let valor = this.cliente.documento.replace(/\D/g, '');

    // CPF
    if (valor.length <= 11) {
      this.cliente.tipoPessoa = 'PF';

      valor = valor.replace(/(\d{3})(\d)/, '$1.$2');
      valor = valor.replace(/(\d{3})(\d)/, '$1.$2');
      valor = valor.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
    } 
    // CNPJ
    else {
      this.cliente.tipoPessoa = 'PJ';

      valor = valor.replace(/^(\d{2})(\d)/, '$1.$2');
      valor = valor.replace(/^(\d{2})\.(\d{3})(\d)/, '$1.$2.$3');
      valor = valor.replace(/\.(\d{3})(\d)/, '.$1/$2');
      valor = valor.replace(/(\d{4})(\d)/, '$1-$2');
    }

    this.cliente.documento = valor;
  }

  salvar() {

    if (!this.cliente.nome || !this.cliente.documento) {
      alert('Preencha nome e documento!');
      return;
    }

    this.clienteService.adicionarCliente(this.cliente).subscribe({
      next: () => {
        alert('Cliente salvo com sucesso!');
        this.router.navigate(['/clientes']);
      },
      error: (erro) => {
        
        console.log(erro); // 👈 ajuda a entender o erro

        if (erro.status === 400 || erro.status === 409 ) {
          alert('Documento já cadastrado');          
        } else {
          alert('Erro ao salvar cliente')
        }
      }
    });
  }

}
