import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../services/usuario.service';
import { environment } from 'src/environments/environment';
import { UsuarioGrid } from '../models/usuario.grid';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
})
export class ListaComponent implements OnInit {
  imagens: string = environment.imagensUrl;

  public usuarios: UsuarioGrid[] = [];
  errorMessage: string;

  constructor(private usuarioService: UsuarioService) {}

  ngOnInit(): void {
    this.usuarioService.obterTodos().subscribe(
      (usuarios) => (this.usuarios = usuarios),
      (error) => (this.errorMessage = error)
    );
  }
}
