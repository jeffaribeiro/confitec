import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { BaseService } from 'src/app/services/base.service';
import { UsuarioGrid } from '../models/usuario.grid';
import { UsuarioDetalhe } from '../models/usuario.detalhe';
import { UsuarioForm } from '../models/usuario.form';

@Injectable()
export class UsuarioService extends BaseService {
  constructor(private http: HttpClient) {
    super();
  }

  obterTodos(): Observable<UsuarioGrid[]> {
    return this.http
      .get<UsuarioGrid[]>(
        this.UrlServiceV1 + 'usuario',
        super.ObterAuthHeaderJson()
      )
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  obterPorId(id: number): Observable<UsuarioDetalhe> {
    return this.http
      .get<UsuarioDetalhe>(
        this.UrlServiceV1 + 'usuario/' + id,
        super.ObterAuthHeaderJson()
      )
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  novoUsuario(usuario: UsuarioForm): Observable<UsuarioForm> {
    return this.http
      .post(this.UrlServiceV1 + 'usuario', usuario, super.ObterAuthHeaderJson())
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  atualizarUsuario(usuario: UsuarioForm): Observable<UsuarioForm> {
    return this.http
      .put(
        this.UrlServiceV1 + 'usuario/' + usuario.idUsuario,
        usuario,
        super.ObterAuthHeaderJson()
      )
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  excluirUsuario(id: number): Observable<UsuarioForm> {
    return this.http
      .delete(this.UrlServiceV1 + 'usuario/' + id, super.ObterAuthHeaderJson())
      .pipe(map(super.extractData), catchError(super.serviceError));
  }
}
