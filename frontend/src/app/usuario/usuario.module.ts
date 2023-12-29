import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TextMaskModule } from 'angular2-text-mask';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ImageCropperModule } from 'ngx-image-cropper';

import { UsuarioRoutingModule } from './usuario.route';
import { UsuarioAppComponent } from './usuario.app.component';
import { ListaComponent } from './lista/lista.component';
import { NovoComponent } from './novo/novo.component';
import { EditarComponent } from './editar/editar.component';
import { ExcluirComponent } from './excluir/excluir.component';
import { DetalhesComponent } from './detalhes/detalhes.component';
import { UsuarioService } from './services/usuario.service';
import { UsuarioResolve } from './services/usuario.resolve';
import { UsuarioGuard } from './services/usuario.guard';
import { EscolaridadeService } from '../escolaridade/services/escolaridade.service';

@NgModule({
  declarations: [
    UsuarioAppComponent,
    ListaComponent,
    NovoComponent,
    EditarComponent,
    ExcluirComponent,
    DetalhesComponent,
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    TextMaskModule,
    NgxSpinnerModule,
    FormsModule,
    ReactiveFormsModule,
    ImageCropperModule,
  ],
  providers: [
    EscolaridadeService,
    UsuarioService,
    UsuarioResolve,
    UsuarioGuard,
  ],
})
export class UsuarioModule {}
