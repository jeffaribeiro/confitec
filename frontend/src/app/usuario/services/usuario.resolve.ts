import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { UsuarioService } from './usuario.service';
import { UsuarioDetalhe } from '../models/usuario.detalhe';

@Injectable()
export class UsuarioResolve implements Resolve<UsuarioDetalhe> {
  constructor(private usuarioService: UsuarioService) {}

  resolve(route: ActivatedRouteSnapshot) {
    return this.usuarioService.obterPorId(route.params['idUsuario']);
  }
}
