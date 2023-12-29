import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsuarioAppComponent } from './usuario.app.component';
import { ListaComponent } from './lista/lista.component';
import { NovoComponent } from './novo/novo.component';
import { EditarComponent } from './editar/editar.component';
import { DetalhesComponent } from './detalhes/detalhes.component';
import { ExcluirComponent } from './excluir/excluir.component';
import { UsuarioResolve } from './services/usuario.resolve';
import { UsuarioGuard } from './services/usuario.guard';

const usuarioRouterConfig: Routes = [
  {
    path: '',
    component: UsuarioAppComponent,
    children: [
      { path: 'listar-todos', component: ListaComponent },
      {
        path: 'adicionar-novo',
        component: NovoComponent,
        //canDeactivate: [UsuarioGuard],
        //canActivate: [UsuarioGuard],
        //data: [{ claim: { nome: 'Usuario', valor: 'Adicionar' } }],
      },
      {
        path: 'editar/:idUsuario',
        component: EditarComponent,
        //canActivate: [UsuarioGuard],
        //data: [{ claim: { nome: 'Usuario', valor: 'Atualizar' } }],
        resolve: {
          usuario: UsuarioResolve,
        },
      },
      {
        path: 'detalhes/:idUsuario',
        component: DetalhesComponent,
        resolve: {
          usuario: UsuarioResolve,
        },
      },
      {
        path: 'excluir/:idUsuario',
        component: ExcluirComponent,
        //canActivate: [UsuarioGuard],
        //data: [{ claim: { nome: 'Usuario', valor: 'Excluir' } }],
        resolve: {
          usuario: UsuarioResolve,
        },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(usuarioRouterConfig)],
  exports: [RouterModule],
})
export class UsuarioRoutingModule {}
