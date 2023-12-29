import { Component } from '@angular/core';
import { UsuarioDetalhe } from '../models/usuario.detalhe';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
})
export class DetalhesComponent {
  imagens: string = environment.imagensUrl;
  usuario: UsuarioDetalhe;

  constructor(private route: ActivatedRoute) {
    this.usuario = this.route.snapshot.data['usuario'];
  }
}
