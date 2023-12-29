import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from '../services/usuario.service';

import { ToastrService } from 'ngx-toastr';

import { UsuarioForm } from '../models/usuario.form';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
})
export class ExcluirComponent {
  usuario: UsuarioForm;

  constructor(
    private usuarioService: UsuarioService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.usuario = this.route.snapshot.data['usuario'];
  }

  public excluirUsuario() {
    this.usuarioService.excluirUsuario(this.usuario.idUsuario).subscribe(
      (evento) => {
        this.sucessoExclusao(evento);
      },
      () => {
        this.falha();
      }
    );
  }

  public sucessoExclusao(evento: any) {
    const toast = this.toastr.success(
      'Usuario excluido com Sucesso!',
      'Good bye :D'
    );
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/usuarios/listar-todos']);
      });
    }
  }

  public falha() {
    this.toastr.error('Houve um erro no processamento!', 'Ops! :(');
  }
}
