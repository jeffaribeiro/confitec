import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { BaseService } from 'src/app/services/base.service';
import { EscolaridadeGrid } from '../models/escolaridade.grid';

@Injectable()
export class EscolaridadeService extends BaseService {
  constructor(private http: HttpClient) {
    super();
  }

  obterTodos(): Observable<EscolaridadeGrid[]> {
    return this.http
      .get<EscolaridadeGrid[]>(
        this.UrlServiceV1 + 'escolaridade',
        super.ObterAuthHeaderJson()
      )
      .pipe(map(super.extractData), catchError(super.serviceError));
  }
}
