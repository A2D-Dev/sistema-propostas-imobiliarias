import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'documento',
  standalone: true
})
export class DocumentoPipe implements PipeTransform {

  transform(valor: string): string {
    if (!valor) return '';

    const somenteNumeros = valor.replace(/\D/g, '');

    // CPF (11 dígitos)
    if (somenteNumeros.length === 11) {
      return somenteNumeros.replace(
        /(\d{3})(\d{3})(\d{3})(\d{2})/,
        '$1.$2.$3-$4'
      );
    }

    // CNPJ (14 dígitos)
    if (somenteNumeros.length === 14) {
      return somenteNumeros.replace(
        /(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/,
        '$1.$2.$3/$4-$5'
      );
    }

    return valor;
  }
}