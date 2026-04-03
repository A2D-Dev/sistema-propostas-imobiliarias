import { Routes } from '@angular/router';
import { DashboardComponent } from './features/dashboard/pages/dashboard/dashboard.component';
import { ListaClientesComponent } from './features/clientes/pages/lista-clientes/lista-clientes.component';
import { CadastroClienteComponent } from './features/clientes/pages/cadastro-cliente/cadastro-cliente.component';
export const routes: Routes = [
    
    {
        path: '',
        component: DashboardComponent // 👉 tela inicial
    },
    {
        path: 'clientes',
        component: ListaClientesComponent
    },
    {
        path: 'clientes/novo',
        component: CadastroClienteComponent
    },
    {
        path: 'clientes/editar/:id'
        component: CadastroClienteComponent
    }


];
